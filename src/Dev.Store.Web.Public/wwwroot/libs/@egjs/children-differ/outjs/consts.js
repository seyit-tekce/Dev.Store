/*
egjs-children-differ
Copyright (c) 2019-present NAVER Corp.
MIT license
*/
export var findKeyCallback = typeof Map === "function"
    ? undefined
    : (function () {
        var childrenCount = 0;
        return function (el) { return el.__DIFF_KEY__ || (el.__DIFF_KEY__ = ++childrenCount); };
    })();
//# sourceMappingURL=consts.js.map