"use strict";
var MyMath;
(function (MyMath) {
    let Circle;
    (function (Circle) {
        const pi = 3.1415;
        function calculateCircumference(diameter) {
            return diameter * pi;
        }
        Circle.calculateCircumference = calculateCircumference;
    })(Circle = MyMath.Circle || (MyMath.Circle = {}));
})(MyMath || (MyMath = {}));
