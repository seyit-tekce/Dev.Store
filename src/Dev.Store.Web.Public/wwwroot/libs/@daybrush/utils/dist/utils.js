var __spreadArray = (this && this.__spreadArray) || function (to, from) {
    for (var i = 0, il = from.length, j = to.length; i < il; i++, j++)
        to[j] = from[i];
    return to;
};
import { UNDEFINED, STRING, OBJECT, FUNCTION, IS_WINDOW, OPEN_CLOSED_CHARACTERS, NUMBER, DEFAULT_UNIT_PRESETS, TINY_NUM } from "./consts";
/**
* @namespace
* @name Utils
*/
/**
 * Returns the inner product of two numbers(`a1`, `a2`) by two criteria(`b1`, `b2`).
 * @memberof Utils
 * @param - The first number
 * @param - The second number
 * @param - The first number to base on the inner product
 * @param - The second number to base on the inner product
 * @return - Returns the inner product
import { dot } from "@daybrush/utils";

console.log(dot(0, 15, 2, 3)); // 6
console.log(dot(5, 15, 2, 3)); // 9
console.log(dot(5, 15, 1, 1)); // 10
 */
export function dot(a1, a2, b1, b2) {
    return (a1 * b2 + a2 * b1) / (b1 + b2);
}
/**
* Check the type that the value is undefined.
* @memberof Utils
* @param {string} value - Value to check the type
* @return {boolean} true if the type is correct, false otherwise
* @example
import {isUndefined} from "@daybrush/utils";

console.log(isUndefined(undefined)); // true
console.log(isUndefined("")); // false
console.log(isUndefined(1)); // false
console.log(isUndefined(null)); // false
*/
export function isUndefined(value) {
    return (typeof value === UNDEFINED);
}
/**
* Check the type that the value is object.
* @memberof Utils
* @param {string} value - Value to check the type
* @return {} true if the type is correct, false otherwise
* @example
import {isObject} from "@daybrush/utils";

console.log(isObject({})); // true
console.log(isObject(undefined)); // false
console.log(isObject("")); // false
console.log(isObject(null)); // false
*/
export function isObject(value) {
    return value && (typeof value === OBJECT);
}
/**
* Check the type that the value is isArray.
* @memberof Utils
* @param {string} value - Value to check the type
* @return {} true if the type is correct, false otherwise
* @example
import {isArray} from "@daybrush/utils";

console.log(isArray([])); // true
console.log(isArray({})); // false
console.log(isArray(undefined)); // false
console.log(isArray(null)); // false
*/
export function isArray(value) {
    return Array.isArray(value);
}
/**
* Check the type that the value is string.
* @memberof Utils
* @param {string} value - Value to check the type
* @return {} true if the type is correct, false otherwise
* @example
import {isString} from "@daybrush/utils";

console.log(isString("1234")); // true
console.log(isString(undefined)); // false
console.log(isString(1)); // false
console.log(isString(null)); // false
*/
export function isString(value) {
    return typeof value === STRING;
}
export function isNumber(value) {
    return typeof value === NUMBER;
}
/**
* Check the type that the value is function.
* @memberof Utils
* @param {string} value - Value to check the type
* @return {} true if the type is correct, false otherwise
* @example
import {isFunction} from "@daybrush/utils";

console.log(isFunction(function a() {})); // true
console.log(isFunction(() => {})); // true
console.log(isFunction("1234")); // false
console.log(isFunction(1)); // false
console.log(isFunction(null)); // false
*/
export function isFunction(value) {
    return typeof value === FUNCTION;
}
function isEqualSeparator(character, separator) {
    var isCharacterSpace = character === "" || character == " ";
    var isSeparatorSpace = separator === "" || separator == " ";
    return (isSeparatorSpace && isCharacterSpace) || character === separator;
}
function findOpen(openCharacter, texts, index, length, openCloseCharacters) {
    var isIgnore = findIgnore(openCharacter, texts, index);
    if (!isIgnore) {
        return findClose(openCharacter, texts, index + 1, length, openCloseCharacters);
    }
    return index;
}
function findIgnore(character, texts, index) {
    if (!character.ignore) {
        return null;
    }
    var otherText = texts.slice(Math.max(index - 3, 0), index + 3).join("");
    return new RegExp(character.ignore).exec(otherText);
}
function findClose(closeCharacter, texts, index, length, openCloseCharacters) {
    var _loop_1 = function (i) {
        var character = texts[i].trim();
        if (character === closeCharacter.close && !findIgnore(closeCharacter, texts, i)) {
            return { value: i };
        }
        var nextIndex = i;
        // re open
        var openCharacter = find(openCloseCharacters, function (_a) {
            var open = _a.open;
            return open === character;
        });
        if (openCharacter) {
            nextIndex = findOpen(openCharacter, texts, i, length, openCloseCharacters);
        }
        if (nextIndex === -1) {
            return out_i_1 = i, "break";
        }
        i = nextIndex;
        out_i_1 = i;
    };
    var out_i_1;
    for (var i = index; i < length; ++i) {
        var state_1 = _loop_1(i);
        i = out_i_1;
        if (typeof state_1 === "object")
            return state_1.value;
        if (state_1 === "break")
            break;
    }
    return -1;
}
export function splitText(text, splitOptions) {
    var _a = isString(splitOptions) ? {
        separator: splitOptions,
    } : splitOptions, _b = _a.separator, separator = _b === void 0 ? "," : _b, isSeparateFirst = _a.isSeparateFirst, isSeparateOnlyOpenClose = _a.isSeparateOnlyOpenClose, _c = _a.isSeparateOpenClose, isSeparateOpenClose = _c === void 0 ? isSeparateOnlyOpenClose : _c, _d = _a.openCloseCharacters, openCloseCharacters = _d === void 0 ? OPEN_CLOSED_CHARACTERS : _d;
    var openClosedText = openCloseCharacters.map(function (_a) {
        var open = _a.open, close = _a.close;
        if (open === close) {
            return open;
        }
        return open + "|" + close;
    }).join("|");
    var regexText = "(\\s*" + separator + "\\s*|" + openClosedText + "|\\s+)";
    var regex = new RegExp(regexText, "g");
    var texts = text.split(regex).filter(function (chr) {
        return chr && chr !== "undefined";
    });
    var length = texts.length;
    var values = [];
    var tempValues = [];
    function resetTemp() {
        if (tempValues.length) {
            values.push(tempValues.join(""));
            tempValues = [];
            return true;
        }
        return false;
    }
    var _loop_2 = function (i) {
        var character = texts[i].trim();
        var nextIndex = i;
        var openCharacter = find(openCloseCharacters, function (_a) {
            var open = _a.open;
            return open === character;
        });
        var closeCharacter = find(openCloseCharacters, function (_a) {
            var close = _a.close;
            return close === character;
        });
        if (openCharacter) {
            nextIndex = findOpen(openCharacter, texts, i, length, openCloseCharacters);
            if (nextIndex !== -1 && isSeparateOpenClose) {
                if (resetTemp() && isSeparateFirst) {
                    return out_i_2 = i, "break";
                }
                values.push(texts.slice(i, nextIndex + 1).join(""));
                i = nextIndex;
                if (isSeparateFirst) {
                    return out_i_2 = i, "break";
                }
                return out_i_2 = i, "continue";
            }
        }
        else if (closeCharacter && !findIgnore(closeCharacter, texts, i)) {
            var nextOpenCloseCharacters = __spreadArray([], openCloseCharacters);
            nextOpenCloseCharacters.splice(openCloseCharacters.indexOf(closeCharacter), 1);
            return { value: splitText(text, {
                    separator: separator,
                    isSeparateFirst: isSeparateFirst,
                    isSeparateOnlyOpenClose: isSeparateOnlyOpenClose,
                    isSeparateOpenClose: isSeparateOpenClose,
                    openCloseCharacters: nextOpenCloseCharacters,
                }) };
        }
        else if (isEqualSeparator(character, separator) && !isSeparateOnlyOpenClose) {
            resetTemp();
            if (isSeparateFirst) {
                return out_i_2 = i, "break";
            }
            return out_i_2 = i, "continue";
        }
        if (nextIndex === -1) {
            nextIndex = length - 1;
        }
        tempValues.push(texts.slice(i, nextIndex + 1).join(""));
        i = nextIndex;
        out_i_2 = i;
    };
    var out_i_2;
    for (var i = 0; i < length; ++i) {
        var state_2 = _loop_2(i);
        i = out_i_2;
        if (typeof state_2 === "object")
            return state_2.value;
        if (state_2 === "break")
            break;
    }
    if (tempValues.length) {
        values.push(tempValues.join(""));
    }
    return values;
}
/**
* divide text by space.
* @memberof Utils
* @param {string} text - text to divide
* @return {Array} divided texts
* @example
import {spliceSpace} from "@daybrush/utils";

console.log(splitSpace("a b c d e f g"));
// ["a", "b", "c", "d", "e", "f", "g"]
console.log(splitSpace("'a,b' c 'd,e' f g"));
// ["'a,b'", "c", "'d,e'", "f", "g"]
*/
export function splitSpace(text) {
    // divide comma(space)
    return splitText(text, "");
}
/**
* divide text by comma.
* @memberof Utils
* @param {string} text - text to divide
* @return {Array} divided texts
* @example
import {splitComma} from "@daybrush/utils";

console.log(splitComma("a,b,c,d,e,f,g"));
// ["a", "b", "c", "d", "e", "f", "g"]
console.log(splitComma("'a,b',c,'d,e',f,g"));
// ["'a,b'", "c", "'d,e'", "f", "g"]
*/
export function splitComma(text) {
    // divide comma(,)
    // "[^"]*"|'[^']*'
    return splitText(text, ",");
}
/**
* divide text by bracket "(", ")".
* @memberof Utils
* @param {string} text - text to divide
* @return {object} divided texts
* @example
import {splitBracket} from "@daybrush/utils";

console.log(splitBracket("a(1, 2)"));
// {prefix: "a", value: "1, 2", suffix: ""}
console.log(splitBracket("a(1, 2)b"));
// {prefix: "a", value: "1, 2", suffix: "b"}
*/
export function splitBracket(text) {
    var matches = (/([^(]*)\(([\s\S]*)\)([\s\S]*)/g).exec(text);
    if (!matches || matches.length < 4) {
        return {};
    }
    else {
        return { prefix: matches[1], value: matches[2], suffix: matches[3] };
    }
}
/**
* divide text by number and unit.
* @memberof Utils
* @param {string} text - text to divide
* @return {} divided texts
* @example
import {splitUnit} from "@daybrush/utils";

console.log(splitUnit("10px"));
// {prefix: "", value: 10, unit: "px"}
console.log(splitUnit("-10px"));
// {prefix: "", value: -10, unit: "px"}
console.log(splitUnit("a10%"));
// {prefix: "a", value: 10, unit: "%"}
*/
export function splitUnit(text) {
    var matches = /^([^\d|e|\-|\+]*)((?:\d|\.|-|e-|e\+)+)(\S*)$/g.exec(text);
    if (!matches) {
        return { prefix: "", unit: "", value: NaN };
    }
    var prefix = matches[1];
    var value = matches[2];
    var unit = matches[3];
    return { prefix: prefix, unit: unit, value: parseFloat(value) };
}
/**
* transform strings to camel-case
* @memberof Utils
* @param {String} text - string
* @return {String} camel-case string
* @example
import {camelize} from "@daybrush/utils";

console.log(camelize("transform-origin")); // transformOrigin
console.log(camelize("abcd_efg")); // abcdEfg
console.log(camelize("abcd efg")); // abcdEfg
*/
export function camelize(str) {
    return str.replace(/[\s-_]+([^\s-_])/g, function (all, letter) { return letter.toUpperCase(); });
}
/**
* transform a camelized string into a lowercased string.
* @memberof Utils
* @param {string} text - a camel-cased string
* @param {string} [separator="-"] - a separator
* @return {string}  a lowercased string
* @example
import {decamelize} from "@daybrush/utils";

console.log(decamelize("transformOrigin")); // transform-origin
console.log(decamelize("abcdEfg", "_")); // abcd_efg
*/
export function decamelize(str, separator) {
    if (separator === void 0) { separator = "-"; }
    return str.replace(/([a-z])([A-Z])/g, function (all, letter, letter2) { return "" + letter + separator + letter2.toLowerCase(); });
}
/**
* transforms something in an array into an array.
* @memberof Utils
* @param - Array form
* @return an array
* @example
import {toArray} from "@daybrush/utils";

const arr1 = toArray(document.querySelectorAll(".a")); // Element[]
const arr2 = toArray(document.querySelectorAll<HTMLElement>(".a")); // HTMLElement[]
*/
export function toArray(value) {
    return [].slice.call(value);
}
/**
* Date.now() method
* @memberof CrossBrowser
* @return {number} milliseconds
* @example
import {now} from "@daybrush/utils";

console.log(now()); // 12121324241(milliseconds)
*/
export function now() {
    return Date.now ? Date.now() : new Date().getTime();
}
/**
* Returns the index of the first element in the array that satisfies the provided testing function.
* @function
* @memberof CrossBrowser
* @param - The array `findIndex` was called upon.
* @param - A function to execute on each value in the array until the function returns true, indicating that the satisfying element was found.
* @param - Returns defaultIndex if not found by the function.
* @example
import { findIndex } from "@daybrush/utils";

findIndex([{a: 1}, {a: 2}, {a: 3}, {a: 4}], ({ a }) => a === 2); // 1
*/
export function findIndex(arr, callback, defaultIndex) {
    if (defaultIndex === void 0) { defaultIndex = -1; }
    var length = arr.length;
    for (var i = 0; i < length; ++i) {
        if (callback(arr[i], i, arr)) {
            return i;
        }
    }
    return defaultIndex;
}
/**
* Returns the reverse direction index of the first element in the array that satisfies the provided testing function.
* @function
* @memberof CrossBrowser
* @param - The array `findLastIndex` was called upon.
* @param - A function to execute on each value in the array until the function returns true, indicating that the satisfying element was found.
* @param - Returns defaultIndex if not found by the function.
* @example
import { findLastIndex } from "@daybrush/utils";

findLastIndex([{a: 1}, {a: 2}, {a: 3}, {a: 4}], ({ a }) => a === 2); // 1
*/
export function findLastIndex(arr, callback, defaultIndex) {
    if (defaultIndex === void 0) { defaultIndex = -1; }
    var length = arr.length;
    for (var i = length - 1; i >= 0; --i) {
        if (callback(arr[i], i, arr)) {
            return i;
        }
    }
    return defaultIndex;
}
/**
* Returns the value of the reverse direction element in the array that satisfies the provided testing function.
* @function
* @memberof CrossBrowser
* @param - The array `findLast` was called upon.
* @param - A function to execute on each value in the array,
* @param - Returns defalutValue if not found by the function.
* @example
import { find } from "@daybrush/utils";

find([{a: 1}, {a: 2}, {a: 3}, {a: 4}], ({ a }) => a === 2); // {a: 2}
*/
export function findLast(arr, callback, defalutValue) {
    var index = findLastIndex(arr, callback);
    return index > -1 ? arr[index] : defalutValue;
}
/**
* Returns the value of the first element in the array that satisfies the provided testing function.
* @function
* @memberof CrossBrowser
* @param - The array `find` was called upon.
* @param - A function to execute on each value in the array,
* @param - Returns defalutValue if not found by the function.
* @example
import { find } from "@daybrush/utils";

find([{a: 1}, {a: 2}, {a: 3}, {a: 4}], ({ a }) => a === 2); // {a: 2}
*/
export function find(arr, callback, defalutValue) {
    var index = findIndex(arr, callback);
    return index > -1 ? arr[index] : defalutValue;
}
/**
* window.requestAnimationFrame() method with cross browser.
* @function
* @memberof CrossBrowser
* @param {FrameRequestCallback} callback - The function to call when it's time to update your animation for the next repaint.
* @return {number} id
* @example
import {requestAnimationFrame} from "@daybrush/utils";

requestAnimationFrame((timestamp) => {
  console.log(timestamp);
});
*/
export var requestAnimationFrame = /*#__PURE__*/ (function () {
    var firstTime = now();
    var raf = IS_WINDOW
        && (window.requestAnimationFrame || window.webkitRequestAnimationFrame
            || window.mozRequestAnimationFrame || window.msRequestAnimationFrame);
    return raf ? raf.bind(window) : (function (callback) {
        var currTime = now();
        var id = setTimeout(function () {
            callback(currTime - firstTime);
        }, 1000 / 60);
        return id;
    });
})();
/**
* window.cancelAnimationFrame() method with cross browser.
* @function
* @memberof CrossBrowser
* @param {number} handle - the id obtained through requestAnimationFrame method
* @return {void}
* @example
import { requestAnimationFrame, cancelAnimationFrame } from "@daybrush/utils";

const id = requestAnimationFrame((timestamp) => {
  console.log(timestamp);
});

cancelAnimationFrame(id);
*/
export var cancelAnimationFrame = /*#__PURE__*/ (function () {
    var caf = IS_WINDOW
        && (window.cancelAnimationFrame || window.webkitCancelAnimationFrame
            || window.mozCancelAnimationFrame || window.msCancelAnimationFrame);
    return caf
        ? caf.bind(window)
        : (function (handle) { clearTimeout(handle); });
})();
/**
* @function
* @memberof Utils
*/
export function getKeys(obj) {
    return Object.keys(obj);
}
/**
* @function
* @memberof Utils
*/
export function getValues(obj) {
    var keys = getKeys(obj);
    return keys.map(function (key) { return obj[key]; });
}
/**
* @function
* @memberof Utils
*/
export function getEntries(obj) {
    var keys = getKeys(obj);
    return keys.map(function (key) { return [key, obj[key]]; });
}
/**
* @function
* @memberof Utils
*/
export function sortOrders(keys, orders) {
    if (orders === void 0) { orders = []; }
    keys.sort(function (a, b) {
        var index1 = orders.indexOf(a);
        var index2 = orders.indexOf(b);
        if (index2 === -1 && index1 === -1) {
            return 0;
        }
        if (index1 === -1) {
            return 1;
        }
        if (index2 === -1) {
            return -1;
        }
        return index1 - index2;
    });
}
/**
* convert unit size to px size
* @function
* @memberof Utils
*/
export function convertUnitSize(pos, size) {
    var _a = splitUnit(pos), value = _a.value, unit = _a.unit;
    if (isObject(size)) {
        var sizeFunction = size[unit];
        if (sizeFunction) {
            if (isFunction(sizeFunction)) {
                return sizeFunction(value);
            }
            else if (DEFAULT_UNIT_PRESETS[unit]) {
                return DEFAULT_UNIT_PRESETS[unit](value, sizeFunction);
            }
        }
    }
    else if (unit === "%") {
        return value * size / 100;
    }
    if (DEFAULT_UNIT_PRESETS[unit]) {
        return DEFAULT_UNIT_PRESETS[unit](value);
    }
    return value;
}
/**
* calculate between min, max
* @function
* @memberof Utils
*/
export function between(value, min, max) {
    return Math.max(min, Math.min(value, max));
}
export function checkBoundSize(targetSize, compareSize, isMax, ratio) {
    if (ratio === void 0) { ratio = targetSize[0] / targetSize[1]; }
    return [
        [throttle(compareSize[0], TINY_NUM), throttle(compareSize[0] / ratio, TINY_NUM)],
        [throttle(compareSize[1] * ratio, TINY_NUM), throttle(compareSize[1], TINY_NUM)],
    ].filter(function (size) { return size.every(function (value, i) {
        var defaultSize = compareSize[i];
        var throttledSize = throttle(defaultSize, TINY_NUM);
        return isMax ? value <= defaultSize || value <= throttledSize : value >= defaultSize || value >= throttledSize;
    }); })[0] || targetSize;
}
/**
* calculate bound size
* @function
* @memberof Utils
*/
export function calculateBoundSize(size, minSize, maxSize, keepRatio) {
    if (!keepRatio) {
        return size.map(function (value, i) { return between(value, minSize[i], maxSize[i]); });
    }
    var width = size[0], height = size[1];
    var ratio = keepRatio === true ? width / height : keepRatio;
    // width : height = minWidth : minHeight;
    var _a = checkBoundSize(size, minSize, false, ratio), minWidth = _a[0], minHeight = _a[1];
    var _b = checkBoundSize(size, maxSize, true, ratio), maxWidth = _b[0], maxHeight = _b[1];
    if (width < minWidth || height < minHeight) {
        width = minWidth;
        height = minHeight;
    }
    else if (width > maxWidth || height > maxHeight) {
        width = maxWidth;
        height = maxHeight;
    }
    return [width, height];
}
/**
* Add all the numbers.
* @function
* @memberof Utils
*/
export function sum(nums) {
    var length = nums.length;
    var total = 0;
    for (var i = length - 1; i >= 0; --i) {
        total += nums[i];
    }
    return total;
}
/**
* Average all numbers.
* @function
* @memberof Utils
*/
export function average(nums) {
    var length = nums.length;
    var total = 0;
    for (var i = length - 1; i >= 0; --i) {
        total += nums[i];
    }
    return length ? total / length : 0;
}
/**
* Get the angle of two points. (0 <= rad < 359)
* @function
* @memberof Utils
*/
export function getRad(pos1, pos2) {
    var distX = pos2[0] - pos1[0];
    var distY = pos2[1] - pos1[1];
    var rad = Math.atan2(distY, distX);
    return rad >= 0 ? rad : rad + Math.PI * 2;
}
/**
* Get the average point of all points.
* @function
* @memberof Utils
*/
export function getCenterPoint(points) {
    return [0, 1].map(function (i) { return average(points.map(function (pos) { return pos[i]; })); });
}
/**
* Gets the direction of the shape.
* @function
* @memberof Utils
*/
export function getShapeDirection(points) {
    var center = getCenterPoint(points);
    var pos1Rad = getRad(center, points[0]);
    var pos2Rad = getRad(center, points[1]);
    return (pos1Rad < pos2Rad && pos2Rad - pos1Rad < Math.PI) || (pos1Rad > pos2Rad && pos2Rad - pos1Rad < -Math.PI)
        ? 1 : -1;
}
/**
* Get the distance between two points.
* @function
* @memberof Utils
*/
export function getDist(a, b) {
    return Math.sqrt(Math.pow((b ? b[0] : 0) - a[0], 2) + Math.pow((b ? b[1] : 0) - a[1], 2));
}
/**
* throttle number depending on the unit.
* @function
* @memberof Utils
*/
export function throttle(num, unit) {
    if (!unit) {
        return num;
    }
    var reverseUnit = 1 / unit;
    return Math.round(num / unit) / reverseUnit;
}
/**
* throttle number array depending on the unit.
* @function
* @memberof Utils
*/
export function throttleArray(nums, unit) {
    nums.forEach(function (_, i) {
        nums[i] = throttle(nums[i], unit);
    });
    return nums;
}
/**
* @function
* @memberof Utils
*/
export function counter(num) {
    var nums = [];
    for (var i = 0; i < num; ++i) {
        nums.push(i);
    }
    return nums;
}
/**
* @function
* @memberof Utils
*/
export function replaceOnce(text, fromText, toText) {
    var isOnce = false;
    return text.replace(fromText, function () {
        var args = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            args[_i] = arguments[_i];
        }
        if (isOnce) {
            return args[0];
        }
        isOnce = true;
        return isString(toText) ? toText : toText.apply(void 0, args);
    });
}
/**
* @function
* @memberof Utils
*/
export function flat(arr) {
    return arr.reduce(function (prev, cur) {
        return prev.concat(cur);
    }, []);
}
/**
* @function
* @memberof Utils
*/
export function deepFlat(arr) {
    return arr.reduce(function (prev, cur) {
        if (isArray(cur)) {
            prev.push.apply(prev, deepFlat(cur));
        }
        else {
            prev.push(cur);
        }
        return prev;
    }, []);
}
/**
 * @function
 * @memberof Utils
 */
export function pushSet(elements, element) {
    if (elements.indexOf(element) === -1) {
        elements.push(element);
    }
}
//# sourceMappingURL=utils.js.map