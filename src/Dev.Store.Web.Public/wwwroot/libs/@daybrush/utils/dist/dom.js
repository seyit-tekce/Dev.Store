import { document } from "./consts";
import { isObject } from "./utils";
/**
 * Returns all element descendants of node that
 * match selectors.
 */
/**
 * Checks if the specified class value exists in the element's class attribute.
 * @memberof DOM
 * @param - A DOMString containing one or more selectors to match
 * @param - If multi is true, a DOMString containing one or more selectors to match against.
 * @example
import {$} from "@daybrush/utils";

console.log($("div")); // div element
console.log($("div", true)); // [div, div] elements
*/
export function $(selectors, multi) {
    if (!document) {
        return multi ? [] : null;
    }
    return multi ? document.querySelectorAll(selectors) : document.querySelector(selectors);
}
/**
* Checks if the specified class value exists in the element's class attribute.
* @memberof DOM
* @param element - target
* @param className - the class name to search
* @return {boolean} return false if the class is not found.
* @example
import {hasClass} from "@daybrush/utils";

console.log(hasClass(element, "start")); // true or false
*/
export function hasClass(element, className) {
    if (element.classList) {
        return element.classList.contains(className);
    }
    return !!element.className.match(new RegExp("(\\s|^)" + className + "(\\s|$)"));
}
/**
* Add the specified class value. If these classe already exist in the element's class attribute they are ignored.
* @memberof DOM
* @param element - target
* @param className - the class name to add
* @example
import {addClass} from "@daybrush/utils";

addClass(element, "start");
*/
export function addClass(element, className) {
    if (element.classList) {
        element.classList.add(className);
    }
    else {
        element.className += " " + className;
    }
}
/**
* Removes the specified class value.
* @memberof DOM
* @param element - target
* @param className - the class name to remove
* @example
import {removeClass} from "@daybrush/utils";

removeClass(element, "start");
*/
export function removeClass(element, className) {
    if (element.classList) {
        element.classList.remove(className);
    }
    else {
        var reg = new RegExp("(\\s|^)" + className + "(\\s|$)");
        element.className = element.className.replace(reg, " ");
    }
}
/**
* Gets the CSS properties from the element.
* @memberof DOM
* @param elements - elements
* @param properites - the CSS properties
* @return returns CSS properties and values.
* @example
import {fromCSS} from "@daybrush/utils";

console.log(fromCSS(element, ["left", "opacity", "top"])); // {"left": "10px", "opacity": 1, "top": "10px"}
*/
export function fromCSS(elements, properties) {
    if (!elements || !properties || !properties.length) {
        return {};
    }
    var element;
    if (elements instanceof Element) {
        element = elements;
    }
    else if (elements.length) {
        element = elements[0];
    }
    else {
        return {};
    }
    var cssObject = {};
    var styles = getWindow(element).getComputedStyle(element);
    var length = properties.length;
    for (var i = 0; i < length; ++i) {
        cssObject[properties[i]] = styles[properties[i]];
    }
    return cssObject;
}
/**
* Sets up a function that will be called whenever the specified event is delivered to the target
* @memberof DOM
* @param - event target
* @param - A case-sensitive string representing the event type to listen for.
* @param - The object which receives a notification (an object that implements the Event interface) when an event of the specified type occurs
* @param - An options object that specifies characteristics about the event listener.
* @example
import {addEvent} from "@daybrush/utils";

addEvent(el, "click", e => {
  console.log(e);
});
*/
export function addEvent(el, type, listener, options) {
    el.addEventListener(type, listener, options);
}
/**
* removes from the EventTarget an event listener previously registered with EventTarget.addEventListener()
* @memberof DOM
* @param - event target
* @param - A case-sensitive string representing the event type to listen for.
* @param - The EventListener function of the event handler to remove from the event target.
* @param - An options object that specifies characteristics about the event listener.
* @example
import {addEvent, removeEvent} from "@daybrush/utils";
const listener = e => {
  console.log(e);
};
addEvent(el, "click", listener);
removeEvent(el, "click", listener);
*/
export function removeEvent(el, type, listener, options) {
    el.removeEventListener(type, listener, options);
}
export function getDocument(el) {
    return (el === null || el === void 0 ? void 0 : el.ownerDocument) || document;
}
export function getDocumentElement(el) {
    return getDocument(el).documentElement;
}
export function getDocumentBody(el) {
    return getDocument(el).body;
}
export function getWindow(el) {
    var _a;
    return ((_a = el === null || el === void 0 ? void 0 : el.ownerDocument) === null || _a === void 0 ? void 0 : _a.defaultView) || window;
}
export function isWindow(val) {
    return val && "postMessage" in val && "blur" in val && "self" in val;
}
export function isNode(el) {
    return isObject(el) && el.nodeName && el.nodeType && "ownerDocument" in el;
}
//# sourceMappingURL=dom.js.map