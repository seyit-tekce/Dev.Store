/**
* @namespace
* @name Consts
*/
/**
* get string "rgb"
* @memberof Color
* @example
import {RGB} from "@daybrush/utils";

console.log(RGB); // "rgb"
*/
export var RGB = "rgb";
/**
* get string "rgba"
* @memberof Color
* @example
import {RGBA} from "@daybrush/utils";

console.log(RGBA); // "rgba"
*/
export var RGBA = "rgba";
/**
* get string "hsl"
* @memberof Color
* @example
import {HSL} from "@daybrush/utils";

console.log(HSL); // "hsl"
*/
export var HSL = "hsl";
/**
* get string "hsla"
* @memberof Color
* @example
import {HSLA} from "@daybrush/utils";

console.log(HSLA); // "hsla"
*/
export var HSLA = "hsla";
/**
* gets an array of color models.
* @memberof Color
* @example
import {COLOR_MODELS} from "@daybrush/utils";

console.log(COLOR_MODELS); // ["rgb", "rgba", "hsl", "hsla"];
*/
export var COLOR_MODELS = [RGB, RGBA, HSL, HSLA];
/**
* get string "function"
* @memberof Consts
* @example
import {FUNCTION} from "@daybrush/utils";

console.log(FUNCTION); // "function"
*/
export var FUNCTION = "function";
/**
* get string "property"
* @memberof Consts
* @example
import {PROPERTY} from "@daybrush/utils";

console.log(PROPERTY); // "property"
*/
export var PROPERTY = "property";
/**
* get string "array"
* @memberof Consts
* @example
import {ARRAY} from "@daybrush/utils";

console.log(ARRAY); // "array"
*/
export var ARRAY = "array";
/**
* get string "object"
* @memberof Consts
* @example
import {OBJECT} from "@daybrush/utils";

console.log(OBJECT); // "object"
*/
export var OBJECT = "object";
/**
* get string "string"
* @memberof Consts
* @example
import {STRING} from "@daybrush/utils";

console.log(STRING); // "string"
*/
export var STRING = "string";
/**
* get string "number"
* @memberof Consts
* @example
import {NUMBER} from "@daybrush/utils";

console.log(NUMBER); // "number"
*/
export var NUMBER = "number";
/**
* get string "undefined"
* @memberof Consts
* @example
import {UNDEFINED} from "@daybrush/utils";

console.log(UNDEFINED); // "undefined"
*/
export var UNDEFINED = "undefined";
/**
* Check whether the environment is window or node.js.
* @memberof Consts
* @example
import {IS_WINDOW} from "@daybrush/utils";

console.log(IS_WINDOW); // false in node.js
console.log(IS_WINDOW); // true in browser
*/
export var IS_WINDOW = typeof window !== UNDEFINED;
/**
* Check whether the environment is window or node.js.
* @memberof Consts
* @name document
* @example
import {IS_WINDOW} from "@daybrush/utils";

console.log(IS_WINDOW); // false in node.js
console.log(IS_WINDOW); // true in browser
*/
var doc = (typeof document !== UNDEFINED && document); // FIXME: this type maybe false
export { doc as document };
var prefixes = ["webkit", "ms", "moz", "o"];
/**
 * @namespace CrossBrowser
 */
/**
* Get a CSS property with a vendor prefix that supports cross browser.
* @function
* @param {string} property - A CSS property
* @return {string} CSS property with cross-browser vendor prefix
* @memberof CrossBrowser
* @example
import {getCrossBrowserProperty} from "@daybrush/utils";

console.log(getCrossBrowserProperty("transform")); // "transform", "-ms-transform", "-webkit-transform"
console.log(getCrossBrowserProperty("filter")); // "filter", "-webkit-filter"
*/
export var getCrossBrowserProperty = /*#__PURE__*/ function (property) {
    if (!doc) {
        return "";
    }
    var styles = (doc.body || doc.documentElement).style;
    var length = prefixes.length;
    if (typeof styles[property] !== UNDEFINED) {
        return property;
    }
    for (var i = 0; i < length; ++i) {
        var name_1 = "-" + prefixes[i] + "-" + property;
        if (typeof styles[name_1] !== UNDEFINED) {
            return name_1;
        }
    }
    return "";
};
/**
* get string "transfrom" with the vendor prefix.
* @memberof CrossBrowser
* @example
import {TRANSFORM} from "@daybrush/utils";

console.log(TRANSFORM); // "transform", "-ms-transform", "-webkit-transform"
*/
export var TRANSFORM = /*#__PURE__*/ getCrossBrowserProperty("transform");
/**
* get string "filter" with the vendor prefix.
* @memberof CrossBrowser
* @example
import {FILTER} from "@daybrush/utils";

console.log(FILTER); // "filter", "-ms-filter", "-webkit-filter"
*/
export var FILTER = /*#__PURE__*/ getCrossBrowserProperty("filter");
/**
* get string "animation" with the vendor prefix.
* @memberof CrossBrowser
* @example
import {ANIMATION} from "@daybrush/utils";

console.log(ANIMATION); // "animation", "-ms-animation", "-webkit-animation"
*/
export var ANIMATION = /*#__PURE__*/ getCrossBrowserProperty("animation");
/**
* get string "keyframes" with the vendor prefix.
* @memberof CrossBrowser
* @example
import {KEYFRAMES} from "@daybrush/utils";

console.log(KEYFRAMES); // "keyframes", "-ms-keyframes", "-webkit-keyframes"
*/
export var KEYFRAMES = /*#__PURE__*/ ANIMATION.replace("animation", "keyframes");
export var OPEN_CLOSED_CHARACTERS = [
    { open: "(", close: ")" },
    { open: "\"", close: "\"" },
    { open: "'", close: "'" },
    { open: "\\\"", close: "\\\"" },
    { open: "\\'", close: "\\'" },
];
export var TINY_NUM = 0.0000001;
export var REVERSE_TINY_NUM = 1 / TINY_NUM;
export var DEFAULT_UNIT_PRESETS = {
    "cm": function (pos) { return pos * 96 / 2.54; },
    "mm": function (pos) { return pos * 96 / 254; },
    "in": function (pos) { return pos * 96; },
    "pt": function (pos) { return pos * 96 / 72; },
    "pc": function (pos) { return pos * 96 / 6; },
    "%": function (pos, size) { return pos * size / 100; },
    "vw": function (pos, size) {
        if (size === void 0) { size = window.innerWidth; }
        return pos / 100 * size;
    },
    "vh": function (pos, size) {
        if (size === void 0) { size = window.innerHeight; }
        return pos / 100 * size;
    },
    "vmax": function (pos, size) {
        if (size === void 0) { size = Math.max(window.innerWidth, window.innerHeight); }
        return pos / 100 * size;
    },
    "vmin": function (pos, size) {
        if (size === void 0) { size = Math.min(window.innerWidth, window.innerHeight); }
        return pos / 100 * size;
    },
};
//# sourceMappingURL=consts.js.map