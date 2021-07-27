import React from "react";
import { render, unmountComponentAtNode } from "react-dom";
import { act } from "react-dom/test-utils";

import TextDataPoint from "./TextDataPoint";

let container = null;
beforeEach(() => {
  // setup a DOM element as a render target
  container = document.createElement("div");
  document.body.appendChild(container);
});

afterEach(() => {
  // cleanup on exiting
  unmountComponentAtNode(container);
  container.remove();
  container = null;
});

it("TextDataPoint renders without units", () => {
  act(() => {
    render(
      <TextDataPoint dataPointTitle="Title" dataPointData="Data" units="" />,
      container
    );
  });
  expect(container.textContent).toBe("Title: Data");
});
