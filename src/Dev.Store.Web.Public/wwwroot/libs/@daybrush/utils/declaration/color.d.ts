/**
* @namespace
* @name Color
*/
/**
* Remove the # from the hex color.
* @memberof Color
* @param {} hex - hex color
* @return {} hex color
* @example
import {cutHex} from "@daybrush/utils";

console.log(cutHex("#000000")) // "000000"
*/
export declare function cutHex(hex: string): string;
/**
* convert hex color to rgb color.
* @memberof Color
* @param {} hex - hex color
* @return {} rgb color
* @example
import {hexToRGBA} from "@daybrush/utils";

console.log(hexToRGBA("#00000005"));
// [0, 0, 0, 1]
console.log(hexToRGBA("#201045"));
// [32, 16, 69, 1]
*/
export declare function hexToRGBA(hex: string): [number, number, number, number];
/**
* convert 3(or 4)-digit hex color to 6(or 8)-digit hex color.
* @memberof Color
* @param {} hex - 3(or 4)-digit hex color
* @return {} 6(or 8)-digit hex color
* @example
import {toFullHex} from "@daybrush/utils";

console.log(toFullHex("#123")); // "#112233"
console.log(toFullHex("#123a")); // "#112233aa"
*/
export declare function toFullHex(h: string): string;
/**
* convert hsl color to rgba color.
* @memberof Color
* @param {} hsl - hsl color(hue: 0 ~ 360, saturation: 0 ~ 1, lightness: 0 ~ 1, alpha: 0 ~ 1)
* @return {} rgba color
* @example
import {hslToRGBA} from "@daybrush/utils";

console.log(hslToRGBA([150, 0.5, 0.4]));
// [51, 153, 102, 1]
*/
export declare function hslToRGBA(hsl: readonly [number, number, number, number?]): [number, number, number, number];
/**
* convert string to rgba color.
* @memberof Color
* @param {} - 3-hex(#000), 4-hex(#0000) 6-hex(#000000), 8-hex(#00000000) or RGB(A), or HSL(A)
* @return {} rgba color
* @example
import {stringToRGBA} from "@daybrush/utils";

console.log(stringToRGBA("#000000")); // [0, 0, 0, 1]
console.log(stringToRGBA("rgb(100, 100, 100)")); // [100, 100, 100, 1]
console.log(stringToRGBA("hsl(150, 0.5, 0.4)")); // [51, 153, 102, 1]
*/
export declare function stringToRGBA(color: string): [number, number, number, number];
