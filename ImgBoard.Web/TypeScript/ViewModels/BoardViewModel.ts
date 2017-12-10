namespace ViewModels {
    export class BoardViewModel {
        Action: KnockoutObservable<string>;
        Images: KnockoutObservableArray<FrontModels.Image>;
        Term: KnockoutObservable<string>;

        Search: () => void;
        ApplySearchResult: (action: string, images: Array<Models.IImage>, timeStart: number) => void;

        constructor(images: Array<Models.IImage>) {
            this.Action = ko.observable("All images");
            this.Term = ko.observable("");
            this.Images = ko.observableArray(images.map(el => new FrontModels.Image(el)));

            this.Search = () => {
                let timeStart = Date.now();

                $('#mainThrobber').show();
                $('.imagesGrid').hide();

                let term = this.Term();
                if (term.length === 0) {
                    ApiRequests.GetImagesRequest(images => {
                        this.ApplySearchResult("All images", images, timeStart);
                    });
                } else {
                    ApiRequests.GetImagesMatchingCategory(term, images => {
                        this.ApplySearchResult("Matches for : "+term, images, timeStart);
                    });
                }
            };

            this.ApplySearchResult = (
                action: string,
                images: Array<Models.IImage>,
                timeStart: number
            ) => {
                this.Action(action);
                this.Images(images.map(el => new FrontModels.Image(el)));
                Util.SetMinimumTimeout(timeStart, 500, ViewsCode.ResetBoardDom);
            };
        }
    }
}