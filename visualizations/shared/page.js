import { collectFrames, validateFrames, Player } from "./engine.js";
import { paint, errorBanner } from "./render.js";

const SPEEDS = [
  { label: "0.5×", ms: 1400 },
  { label: "1×", ms: 700 },
  { label: "2×", ms: 350 },
  { label: "4×", ms: 175 },
];

function el(tag, className, text) {
  const node = document.createElement(tag);
  if (className) node.className = className;
  if (text !== undefined) node.textContent = text;
  return node;
}

function buildHeader(spec) {
  const header = el("header", "page__header");
  header.append(el("p", "page__folder", spec.folder));
  header.append(el("h1", "page__title", spec.title));
  header.append(el("p", "page__when", spec.whenToUse));

  const meta = el("dl", "page__meta");
  meta.append(el("dt", null, "Time"), el("dd", null, spec.complexity.time));
  meta.append(el("dt", null, "Space"), el("dd", null, spec.complexity.space));
  header.append(meta);

  const problems = el("ul", "page__problems");
  for (const problem of spec.problems) problems.append(el("li", null, problem));
  header.append(el("h2", "page__problems-title", "Problems using this pattern"), problems);

  const home = el("a", "page__home", "← All patterns");
  home.href = "../index.html";
  header.prepend(home);
  return header;
}

function buildPseudocode(spec) {
  const list = el("ol", "code");
  for (const line of spec.pseudocode) {
    const item = el("li", "code__line");
    item.textContent = line;
    list.append(item);
  }
  return list;
}

function buildControls() {
  const bar = el("div", "controls");
  const buttons = {
    first: el("button", "controls__btn", "|◀"),
    prev: el("button", "controls__btn", "◀"),
    toggle: el("button", "controls__btn controls__btn--play", "▶ Play"),
    next: el("button", "controls__btn", "▶"),
    last: el("button", "controls__btn", "▶|"),
  };
  for (const button of Object.values(buttons)) bar.append(button);

  const scrub = el("input", "controls__scrub");
  scrub.type = "range";
  scrub.min = "0";
  scrub.step = "1";
  bar.append(scrub);

  const counter = el("span", "controls__counter");
  bar.append(counter);

  const speed = el("select", "controls__speed");
  for (const option of SPEEDS) {
    const opt = el("option", null, option.label);
    opt.value = String(option.ms);
    if (option.ms === 700) opt.selected = true;
    speed.append(opt);
  }
  bar.append(speed);

  return { bar, buttons, scrub, counter, speed };
}

function buildInputPicker(spec) {
  const wrap = el("div", "inputs");
  const label = el("label", "inputs__label", "Example input");
  label.htmlFor = "input-picker";

  const picker = el("select", "inputs__select");
  picker.id = "input-picker";
  spec.inputs.forEach((input, i) => {
    const option = el("option", null, input.label);
    option.value = String(i);
    picker.append(option);
  });

  wrap.append(label, picker);
  return { wrap, picker };
}

export function boot(spec, root) {
  root.replaceChildren();

  const viz = el("div", "stage__viz");
  const viz2 = el("div", "stage__viz stage__viz--secondary");
  viz2.hidden = true;
  const panels = el("div", "stage__panels");
  panels.append(viz, viz2);

  const codeList = buildPseudocode(spec);
  const stage = el("section", "stage");
  stage.append(panels, codeList);

  const note = el("p", "note");
  const controls = buildControls();
  const inputs = buildInputPicker(spec);
  const picker = inputs.picker;

  root.append(buildHeader(spec), inputs.wrap, stage, note, controls.bar);

  let player = null;
  let frames = [];

  function showFrame(index) {
    const frame = frames[index];
    if (!frame) return;

    paint(frame.view, viz);
    if (frame.view2) {
      viz2.hidden = false;
      paint(frame.view2, viz2);
    } else {
      viz2.hidden = true;
      viz2.replaceChildren();
    }

    for (const [i, line] of [...codeList.children].entries()) {
      line.classList.toggle("is-active", i === frame.line);
    }

    note.textContent = frame.note;
    note.classList.remove("viz-error");
    controls.scrub.value = String(index);
    controls.counter.textContent = `${index + 1} / ${frames.length}`;
    controls.buttons.toggle.textContent = player?.isPlaying ? "❚❚ Pause" : "▶ Play";
  }

  function showError(message) {
    player?.pause();
    frames = [];
    viz.replaceChildren(errorBanner(message));
    viz2.hidden = true;
    note.textContent = message;
    note.classList.add("viz-error");
    for (const button of Object.values(controls.buttons)) button.disabled = true;
    controls.scrub.disabled = true;
  }

  function load(inputIndex) {
    const input = spec.inputs[inputIndex];
    try {
      const collected = collectFrames(spec, input.data);
      const problems = validateFrames(spec, collected.frames);
      if (problems.length > 0) {
        showError(`Invalid frames: ${problems.join("; ")}`);
        return;
      }
      frames = collected.frames;
    } catch (err) {
      showError(err.message);
      return;
    }

    for (const button of Object.values(controls.buttons)) button.disabled = false;
    controls.scrub.disabled = false;
    controls.scrub.max = String(frames.length - 1);

    player?.pause();
    player = new Player(frames.length, {
      onChange: showFrame,
      intervalMs: Number(controls.speed.value),
    });
    showFrame(0);
  }

  controls.buttons.first.addEventListener("click", () => {
    if (!player) return;
    player.first();
  });
  controls.buttons.prev.addEventListener("click", () => {
    if (!player) return;
    player.prev();
  });
  controls.buttons.next.addEventListener("click", () => {
    if (!player) return;
    player.next();
  });
  controls.buttons.last.addEventListener("click", () => {
    if (!player) return;
    player.last();
  });
  controls.buttons.toggle.addEventListener("click", () => {
    if (!player) return;
    player.toggle();
    showFrame(player.index);
  });
  controls.scrub.addEventListener("input", () => player.seek(Number(controls.scrub.value)));
  controls.speed.addEventListener("change", () => player.setSpeed(Number(controls.speed.value)));
  picker.addEventListener("change", () => load(Number(picker.value)));

  document.addEventListener("keydown", (event) => {
    if (event.target instanceof HTMLSelectElement || event.target instanceof HTMLInputElement) return;
    if (!player) return;
    const actions = {
      " ": () => { player.toggle(); showFrame(player.index); },
      ArrowRight: () => player.next(),
      ArrowLeft: () => player.prev(),
      Home: () => player.first(),
      End: () => player.last(),
    };
    const action = actions[event.key];
    if (action) {
      event.preventDefault();
      action();
    }
  });

  load(0);
}
