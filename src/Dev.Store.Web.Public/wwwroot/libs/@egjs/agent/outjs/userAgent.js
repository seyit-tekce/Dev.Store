import { getUserAgentString, findPreset } from "./utils";
import { WEBVIEW_PRESETS, CHROMIUM_PRESETS, BROWSER_PRESETS, OS_PRESETS, WEBKIT_PRESETS } from "./presets";
export function isWebView(userAgent) {
    return !!findPreset(WEBVIEW_PRESETS, userAgent).preset;
}
export function getLegacyAgent(userAgent) {
    var nextAgent = getUserAgentString(userAgent);
    var isMobile = !!/mobi/g.exec(nextAgent);
    var browser = {
        name: "unknown",
        version: "-1",
        majorVersion: -1,
        webview: isWebView(nextAgent),
        chromium: false,
        chromiumVersion: "-1",
        webkit: false,
        webkitVersion: "-1",
    };
    var os = {
        name: "unknown",
        version: "-1",
        majorVersion: -1,
    };
    var _a = findPreset(BROWSER_PRESETS, nextAgent), browserPreset = _a.preset, browserVersion = _a.version;
    var _b = findPreset(OS_PRESETS, nextAgent), osPreset = _b.preset, osVersion = _b.version;
    var chromiumPreset = findPreset(CHROMIUM_PRESETS, nextAgent);
    browser.chromium = !!chromiumPreset.preset;
    browser.chromiumVersion = chromiumPreset.version;
    if (!browser.chromium) {
        var webkitPreset = findPreset(WEBKIT_PRESETS, nextAgent);
        browser.webkit = !!webkitPreset.preset;
        browser.webkitVersion = webkitPreset.version;
    }
    if (osPreset) {
        os.name = osPreset.id;
        os.version = osVersion;
        os.majorVersion = parseInt(osVersion, 10);
    }
    if (browserPreset) {
        browser.name = browserPreset.id;
        browser.version = browserVersion;
        // Early whale bugs
        if (browser.webview && os.name === "ios" && browser.name !== "safari") {
            browser.webview = false;
        }
    }
    browser.majorVersion = parseInt(browser.version, 10);
    return {
        browser: browser,
        os: os,
        isMobile: isMobile,
        isHints: false,
    };
}
//# sourceMappingURL=userAgent.js.map