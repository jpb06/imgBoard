namespace Util {
    export function SetMinimumTimeout(timeStart: number, minimumDelay: number,
                                      action: () => any) {

        let elapsed = Date.now() - timeStart;
        if (elapsed < minimumDelay) {
            setTimeout(function () {
                action();
            }, minimumDelay - elapsed);
        }
        else {
            action();
        }
    }
}