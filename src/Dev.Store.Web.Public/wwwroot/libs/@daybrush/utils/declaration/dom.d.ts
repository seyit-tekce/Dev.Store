import { IObject, IEventMap } from "./types";
/**
 * @namespace DOM
 */
export declare function $<K extends keyof HTMLElementTagNameMap>(selectors: K, multi: true): NodeListOf<HTMLElementTagNameMap[K]>;
export declare function $<K extends keyof SVGElementTagNameMap>(selectors: K, multi: true): NodeListOf<SVGElementTagNameMap[K]>;
export declare function $<E extends Element = Element>(selectors: string, multi: true): NodeListOf<E>;
export declare function $<K extends keyof HTMLElementTagNameMap>(selectors: K, multi?: false): HTMLElementTagNameMap[K] | null;
export declare function $<K extends keyof SVGElementTagNameMap>(selectors: K, multi?: false): SVGElementTagNameMap[K] | null;
export declare function $<E extends Element = Element>(selectors: string, multi?: false): E | null;
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
export declare function hasClass(element: Element, className: string): boolean;
/**
* Add the specified class value. If these classe already exist in the element's class attribute they are ignored.
* @memberof DOM
* @param element - target
* @param className - the class name to add
* @example
import {addClass} from "@daybrush/utils";

addClass(element, "start");
*/
export declare function addClass(element: Element, className: string): void;
/**
* Removes the specified class value.
* @memberof DOM
* @param element - target
* @param className - the class name to remove
* @example
import {removeClass} from "@daybrush/utils";

removeClass(element, "start");
*/
export declare function removeClass(element: Element, className: string): void;
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
export declare function fromCSS(elements: Element | Element[] | NodeListOf<Element>, properties: string[]): IObject<any>;
export declare function addEvent<K extends keyof IEventMap>(el: EventTarget, type: K, listener: (e: IEventMap[K]) => void, options?: boolean | AddEventListenerOptions): void;
export declare function removeEvent<K extends keyof IEventMap>(el: EventTarget, type: K, listener: (e: IEventMap[K]) => void, options?: boolean | EventListenerOptions): void;
export declare function getDocument(el?: Node): Document;
export declare function getDocumentElement(el?: Node): HTMLElement;
export declare function getDocumentBody(el?: Node): HTMLElement;
export declare function getWindow(el?: Node): Window & typeof globalThis;
export declare function isWindow(val: any): val is Window;
export declare function isNode(el?: any): el is Node;
