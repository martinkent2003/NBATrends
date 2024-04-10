"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.loadJSON = void 0;
var https = require("https");
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0';
// loads json data from parameter url
function loadJSON(url) {
    return new Promise(function (resolve, reject) {
        https.get(url, function (res) {
            var data = '';
            res.on('data', function (chunk) {
                data += chunk;
            });
            res.on('end', function () {
                resolve(JSON.parse(data)); // Resolve the promise with the parsed JSON data
            });
        }).on('error', function (err) {
            reject(err); // Reject the promise with the error
        });
    });
}
exports.loadJSON = loadJSON;
