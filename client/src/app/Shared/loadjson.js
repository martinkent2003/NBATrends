"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.doSomethingWithPlayers = exports.loadJSON = void 0;
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
// load json object with player data into players array
function createPlayersArray(data) {
    var players = data.map(function (playerData) {
        return {
            personId: playerData.personId,
            firstName: playerData.firstName,
            lastName: playerData.lastName,
            isActive: playerData.isActive
        };
    });
    return players;
}
// test function - prints first ten players
function printPlayers(players) {
    console.log("First ten players:");
    for (var i = 0; i < 10; i++) {
        var player = players[i];
        console.log("Player ".concat(i + 1, ":"));
        console.log("  Person ID:", player.personId);
        console.log("  First Name:", player.firstName);
        console.log("  Last Name:", player.lastName);
        console.log("  Active:", player.isActive);
    }
}
function doSomethingWithPlayers(data) {
    return __awaiter(this, void 0, void 0, function () {
        var players;
        return __generator(this, function (_a) {
            players = createPlayersArray(data);
            printPlayers(players);
            return [2 /*return*/, players];
        });
    });
}
exports.doSomethingWithPlayers = doSomethingWithPlayers;
// test - confirms data can be loaded
loadJSON(environment.apiUrl + "/players")
    .then(function (data) {
    doSomethingWithPlayers(data);
})
    .catch(function (error) {
    console.error('Error fetching data:', error);
});
