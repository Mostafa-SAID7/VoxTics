---
name: VoxTics partial sections bug
description: @section Scripts/Styles in partial views are silently ignored by ASP.NET Core MVC.
---

## Rule
Never put `@section Scripts` or `@section Styles` inside a `.cshtml` partial view.
ASP.NET Core silently discards them — no error, no output, no execution.

**Why:** The Razor section system only works in views that are directly rendered by a layout. Partial views are inlined at call site; they cannot contribute sections to the parent layout.

**How to apply:**
- If a partial needs JS: move it to `site.js` (global) or have the including view add a `@section Scripts` reference.
- If a partial needs CSS: add it to `voxtics-global.css`.
- This affected `_Pagination.cshtml` (pagination AJAX JS was dead) and `_Loader.cshtml` (loader JS was dead). Both were fixed by moving JS to `site.js`.
