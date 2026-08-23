import { isKnownKind } from "./kinds.js";

export const MAX_FRAMES = 2000;

/**
 * Runs a spec once and collects every emitted frame.
 * Frames are complete snapshots, so the player can seek freely.
 */
export function collectFrames(spec, data) {
  const frames = [];
  const emit = (frame) => {
    if (frames.length >= MAX_FRAMES) {
      throw new Error(
        `frame cap exceeded (${MAX_FRAMES}) in "${spec.title}" — check for a runaway loop`,
      );
    }
    frames.push(frame);
  };
  const result = spec.run(data, emit);
  return { frames, result };
}

/** Returns a list of human-readable problems; an empty array means clean. */
export function validateFrames(spec, frames) {
  const problems = [];
  if (frames.length === 0) problems.push("no frames emitted");

  frames.forEach((frame, i) => {
    const maxLine = spec.pseudocode.length - 1;
    if (!Number.isInteger(frame.line) || frame.line < 0 || frame.line > maxLine) {
      problems.push(`frame ${i}: line ${frame.line} out of range 0..${maxLine}`);
    }
    if (typeof frame.note !== "string" || frame.note.trim() === "") {
      problems.push(`frame ${i}: note must be a non-empty string`);
    }
    if (!frame.view || !isKnownKind(frame.view.kind)) {
      problems.push(`frame ${i}: unknown view kind ${JSON.stringify(frame.view?.kind)}`);
    }
    if (frame.view2 && !isKnownKind(frame.view2.kind)) {
      problems.push(`frame ${i}: unknown view2 kind ${JSON.stringify(frame.view2.kind)}`);
    }
  });

  return problems;
}

/** Owns the current frame index and playback timing. Knows nothing about the DOM. */
export class Player {
  #index = 0;
  #count;
  #timer = null;
  #onChange;
  #intervalMs;
  #schedule;
  #cancel;

  constructor(count, options = {}) {
    const {
      onChange = () => {},
      intervalMs = 700,
      schedule = setInterval,
      cancel = clearInterval,
    } = options;
    this.#count = Math.max(0, count);
    this.#onChange = onChange;
    this.#intervalMs = intervalMs;
    this.#schedule = schedule;
    this.#cancel = cancel;
  }

  get index() { return this.#index; }
  get count() { return this.#count; }
  get isPlaying() { return this.#timer !== null; }
  get atEnd() { return this.#index >= this.#count - 1; }

  seek(target) {
    const last = Math.max(0, this.#count - 1);
    const next = Math.min(last, Math.max(0, target));
    if (next === this.#index) return;
    this.#index = next;
    this.#onChange(this.#index);
  }

  next() { this.seek(this.#index + 1); }
  prev() { this.seek(this.#index - 1); }
  first() { this.seek(0); }
  last() { this.seek(this.#count - 1); }

  play() {
    if (this.isPlaying || this.#count === 0) return;
    if (this.atEnd) this.first();
    // Called through a local binding, never as this.#schedule(...): the browser's
    // setInterval is a WebIDL operation on the global and throws "Illegal
    // invocation" when handed any other receiver.
    const schedule = this.#schedule;
    this.#timer = schedule(() => {
      this.next();
      if (this.atEnd) this.pause();
    }, this.#intervalMs);
    this.#onChange(this.#index);
  }

  pause() {
    if (!this.isPlaying) return;
    const cancel = this.#cancel; // local binding, see play()
    cancel(this.#timer);
    this.#timer = null;
    this.#onChange(this.#index);
  }

  toggle() { this.isPlaying ? this.pause() : this.play(); }

  reset() {
    this.pause();
    this.first();
  }

  setSpeed(intervalMs) {
    this.#intervalMs = intervalMs;
    if (this.isPlaying) {
      this.pause();
      this.play();
    }
  }
}
