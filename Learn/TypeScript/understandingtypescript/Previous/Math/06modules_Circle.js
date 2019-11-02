define(["require", "exports"], function (require, exports) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    exports.pi = 3.1415;
    function calculateCircumference(diameter) {
        return diameter * exports.pi;
    }
    exports.calculateCircumference = calculateCircumference;
});
