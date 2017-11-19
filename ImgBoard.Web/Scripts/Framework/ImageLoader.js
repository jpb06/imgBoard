"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ImageLoader = /** @class */ (function () {
    function ImageLoader() {
    }
    ImageLoader.prototype.Load = function (imageData) {
        return imageData.FileId + '.' + imageData.FileExtension;
    };
    return ImageLoader;
}());
exports.default = ImageLoader;
//# sourceMappingURL=ImageLoader.js.map