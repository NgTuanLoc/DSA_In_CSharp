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
