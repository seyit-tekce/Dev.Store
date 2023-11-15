var __spreadArray = (this && this.__spreadArray) || function (to, from) {
    for (var i = 0, il = from.length, j = to.length; i < il; i++, j++)
        to[j] = from[i];
    return to;
};
import { some, find, findBrand, convertVersion, findPresetBrand, getUserAgentString } from "./utils";
import { BROWSER_PRESETS, OS_PRESETS, CHROMIUM_PRESETS, WEBKIT_PRESETS, WEBVIEW_PRESETS } from "./presets";
import { isWebView } from "./userAgent";
export function getClientHintsAgent(osData) {
    var userAgentData = navigator.userAgentData;
    var brands = __spreadArray([], (userAgentData.uaList || userAgentData.brands));
    var fullVersionList = osData && osData.fullVersionList;
    var isMobile = userAgentData.mobile || false;
    var firstBrand = brands[0];
    var platform = (osData && osData.platform || userAgentData.platform || navigator.platform).toLowerCase();
    var browser = {
        name: firstBrand.brand,
        version: firstBrand.version,
        majorVersion: -1,
        webkit: false,
        webkitVersion: "-1",
        chromium: false,
        chromiumVersion: "-1",
        webview: !!findPresetBrand(WEBVIEW_PRESETS, brands).brand || isWebView(getUserAgentString()),
    };
    var os = {
        name: "unknown",
        version: "-1",
        majorVersion: -1,
    };
    browser.webkit = !browser.chromium && some(WEBKIT_PRESETS, function (preset) { return findBrand(brands, preset); });
    var chromiumBrand = findPresetBrand(CHROMIUM_PRESETS, brands);
    browser.chromium = !!chromiumBrand.brand;
    browser.chromiumVersion = chromiumBrand.version;
    if (!browser.chromium) {
        var webkitBrand = findPresetBrand(WEBKIT_PRESETS, brands);
        browser.webkit = !!webkitBrand.brand;
        browser.webkitVersion = webkitBrand.version;
    }
    var platfomResult = find(OS_PRESETS, function (preset) {
        return new RegExp("" + preset.test, "g").exec(platform);
    });
    os.name = platfomResult ? platfomResult.id : "";
    if (osData) {
        os.version = osData.platformVersion;
    }
    if (fullVersionList && fullVersionList.length) {
        var browserBrandByFullVersionList = findPresetBrand(BROWSER_PRESETS, fullVersionList);
        browser.name = browserBrandByFullVersionList.brand || browser.name;
        browser.version = browserBrandByFullVersionList.version || browser.version;
    }
    else {
        var browserBrand = findPresetBrand(BROWSER_PRESETS, brands);
        browser.name = browserBrand.brand || browser.name;
        browser.version = browserBrand.brand && osData ? osData.uaFullVersion : browserBrand.version;
    }
    if (browser.webkit) {
        os.name = isMobile ? "ios" : "mac";
    }
    if (os.name === "ios" && browser.webview) {
        browser.version = "-1";
    }
    os.version = convertVersion(os.version);
    browser.version = convertVersion(browser.version);
    os.majorVersion = parseInt(os.version, 10);
    browser.majorVersion = parseInt(browser.version, 10);
    return {
        browser: browser,
        os: os,
        isMobile: isMobile,
        isHints: true,
    };
}
//# sourceMappingURL=userAgentData.js.map