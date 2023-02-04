module.exports = {
    aliases: {
        "@node_modules": "./node_modules",
        "@libs": "./wwwroot/libs"
    },
    clean: [

    ],
    mappings: {
        "@node_modules/jquery-slugify/dist/**/*": "@libs/jquery-slugify",
        "@node_modules/speakingurl/speakingurl.min.js": "@libs/speakingurl",
        "@node_modules/speakingurl/speakingurl.min.js": "@libs/speakingurl",
        "@node_modules/@uppy/": "@libs/uppy",
    }
};
    