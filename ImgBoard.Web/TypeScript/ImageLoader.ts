import Image from "./Models/Image";

export default class ImageLoader {
    Load(imageData: Image): string {
        return imageData.FileId + '.' + imageData.FileExtension;
    }
}