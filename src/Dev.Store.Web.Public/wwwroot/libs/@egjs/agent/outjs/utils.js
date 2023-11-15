export function some(arr, callback) {
    var length = arr.length;
    for (var i = 0; i < length; ++i) {
        if (callback(arr[i], i)) {
            return true;
        }
    }
    return false;
}
export function find(arr, callback) {
    var length = arr.length;
    for (var i = 0; i < length; ++i) {
        if (callback(arr[i], i)) {
            return arr[i];
        }
    }
    return null;
}
export function getUserAgentString(agent) {
    var userAgent = agent;
    if (typeof userAgent === "undefined") {
        if (typeof navigator === "undefined" || !navigator) {
            return "";
        }
        userAgent = navigator.userAgent || "";
    }
    return userAgent.toLowerCase();
}
export function execRegExp(pattern, text) {
    try {
        return new RegExp(pattern, "g").exec(text);
    }
    catch (e) {
        return null;
    }
}
export function hasUserAgentData() {
    if (typeof navigator === "undefined" || !navigator || !navigator.userAgentData) {
        return false;
    }
    var userAgentData = navigator.userAgentData;
    var brands = (userAgentData.brands || userAgentData.uaList);
    return !!(brands && brands.length);
}
export function findVersion(versionTest, userAgent) {
    var result = execRegExp("(" + versionTest + ")((?:\\/|\\s|:)([0-9|\\.|_]+))", userAgent);
    return result ? result[3] : "";
}
export function convertVersion(text) {
    return text.replace(/_/g, ".");
}
export function findPreset(presets, userAgent) {
    var userPreset = null;
    var version = "-1";
    some(presets, function (preset) {
        var result = execRegExp("(" + preset.test + ")((?:\\/|\\s|:)([0-9|\\.|_]+))?", userAgent);
        if (!result || preset.brand) {
            return false;
        }
        userPreset = preset;
        version = result[3] || "-1";
        if (preset.versionAlias) {
            version = preset.versionAlias;
        }
        else if (preset.versionTest) {
            version = findVersion(preset.versionTest.toLowerCase(), userAgent) || version;
        }
        version = convertVersion(version);
        return true;
    });
    return {
        preset: userPreset,
        version: version,
    };
}
export function findPresetBrand(presets, brands) {
    var brandInfo = {
        brand: "",
        version: "-1",
    };
    some(presets, function (preset) {
        var result = findBrand(brands, preset);
        if (!result) {
            return false;
        }
        brandInfo.brand = preset.id;
        brandInfo.version = preset.versionAlias || result.version;
        return brandInfo.version !== "-1";
    });
    return brandInfo;
}
export function findBrand(brands, preset) {
    return find(brands, function (_a) {
        var brand = _a.brand;
        return execRegExp("" + preset.test, brand.toLowerCase());
    });
}
//# sourceMappingURL=utils.js.map