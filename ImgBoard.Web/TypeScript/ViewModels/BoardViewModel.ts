namespace ViewModels {
    export class BoardViewModel {
        LastFetchedTerm: string;

        Action: KnockoutObservable<string>;
        Images: KnockoutObservableArray<FrontModels.Image>;
        SearchText: KnockoutObservable<string>;
        Matches: KnockoutObservableArray<FrontModels.Category>;

        Term: KnockoutComputed<string>;

        Search: () => void;
        FetchImagesByMatch: (match: FrontModels.Category) => void;

        ApplySearchResult: (action: string, images: Array<Models.IImage>, timeStart: number) => void;

        constructor(images: Array<Models.IImage>) {
            this.LastFetchedTerm = "";
            this.Action = ko.observable("All images");
            this.SearchText = ko.observable("");
            this.Images = ko.observableArray(images.map(el => new FrontModels.Image(el)));
            this.Matches = ko.observableArray([]);

            this.Term = ko.pureComputed<string>(this.SearchText)
                .extend({ rateLimit: { method: "notifyWhenChangesStop", timeout: 400 } });
            this.Term.subscribe((term) => {
                let timeStart = Date.now();
                if (term.length === 0) {
                    $('#search-matches').hide();
                } else {
                    if (this.LastFetchedTerm !== term) {
                        ApiRequests.GetMatchingCategories(term, categories => {
                            this.Matches(categories.map(el => new FrontModels.Category(el)));
                            $('#search-matches').show();
                        });
                    }
                }
            }, this);

            this.Search = () => {
                let timeStart = Date.now();
                
                let term = this.SearchText();

                if (term.length === 0) {
                    $('#main-throbber').show();
                    $('.images-grid').hide();

                    ApiRequests.GetImagesRequest(images => {
                        this.ApplySearchResult("All images", images, timeStart);
                    });
                } else {
                    if (this.LastFetchedTerm !== term) {
                        ApiRequests.GetMatchingCategories(term, categories => {
                            this.Matches(categories.map(el => new FrontModels.Category(el)));
                            $('#search-matches').show();
                        });
                    }
                }
            };

            this.FetchImagesByMatch = (match: FrontModels.Category) => {
                let timeStart = Date.now();

                this.SearchText(match.Title);
                this.LastFetchedTerm = match.Title;

                $('#search-matches').hide();
                $('#main-throbber').show();
                $('.images-grid').hide();

                ApiRequests.GetImagesByCategory(match.Id, images => {
                    this.ApplySearchResult("Matches for : " + match.Title, images, timeStart);
                });
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