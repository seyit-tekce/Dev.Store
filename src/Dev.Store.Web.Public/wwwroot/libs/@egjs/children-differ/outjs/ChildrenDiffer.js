var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
/*
egjs-children-differ
Copyright (c) 2019-present NAVER Corp.
MIT license
*/
import ListDiffer from "@egjs/list-differ";
import { findKeyCallback } from "./consts";
/**
 * A module that checks diff when child are added, removed, or changed .
 * @ko 자식 노드들에서 자식 노드가 추가되거나 삭제되거나 순서가 변경된 사항을 체크하는 모듈입니다.
 * @memberof eg
 * @extends eg.ListDiffer
 */
var ChildrenDiffer = /** @class */ (function (_super) {
    __extends(ChildrenDiffer, _super);
    /**
     * @param - Initializing Children <ko> 초기 설정할 자식 노드들</ko>
     */
    function ChildrenDiffer(list) {
        if (list === void 0) { list = []; }
        return _super.call(this, list, findKeyCallback) || this;
    }
    return ChildrenDiffer;
}(ListDiffer));
export default ChildrenDiffer;
//# sourceMappingURL=ChildrenDiffer.js.map