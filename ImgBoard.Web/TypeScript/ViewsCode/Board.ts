namespace ViewsCode {
    export function Board() {
        let timeStart = Date.now();
        ApiRequests.GetImagesRequest(images => {
            ko.applyBindings(new ViewModels.BoardViewModel(images));
            
            let elapsed = Date.now() - timeStart;
            if (elapsed < 500) {
                setTimeout(function () {
                    setupBoardDom();
                }, 500 - elapsed);
            }
            else {
                setupBoardDom();
            }
        });
    }

    export function setupBoardDom() {
        $('.imagesGrid').imagesLoaded().progress(function () {
            $('#gridContent').masonry({
                itemSelector: '.grid-item', // use a separate class for itemSelector, other than .col-
                columnWidth: '.grid-sizer',
                percentPosition: true
            });
        });
        $('.imagesGrid').toggle();
        $('#mainThrobber').toggle();
    }
}