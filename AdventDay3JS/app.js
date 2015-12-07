var fs = require('fs');
var readline = require('readline');
var _ = require('lodash');

var calculateSoloHouses = function (input) {

    var currentLocation = { x: 0, y: 0 };
    var locations = [];

    locations.push(currentLocation);
    for (var i = 0; i < input.length; i++) {
      switch(input[i]) {
            case '^':
                // north
              currentLocation = { x: currentLocation.x, y: currentLocation.y+1 };
              break;
            case '>':
                // east
                currentLocation = { x: currentLocation.x+1, y: currentLocation.y };                
                break;
            case 'v':
                // south 
                currentLocation = { x: currentLocation.x, y: currentLocation.y-1 };
                break;
            case '<':
                // west
                currentLocation = { x: currentLocation.x-1, y: currentLocation.y };
                break;
        }
        locations.push(currentLocation);
    }
    var locs = _.uniq(locations, false, function(loc) {
        // comparitor string for _uniq
        return 'x-' + loc.x + '-y-' + loc.y;
    });
    return locs.length;
};

var calculateRoboHouses = function(input) {
    var santaLocation = { x: 0, y: 0 };
    var robotLocation = { x: 0, y: 0 };
    var santaLocations = [];
    var robotLocations = [];
    
    santaLocations.push(santaLocation);
    for (var i = 0; i < input.length; i++) {
        switch (input[i]) {
            case '^':
                // north
                if (i % 2 == 0) {
                    santaLocation = { x: santaLocation.x, y: santaLocation.y + 1 };
                } else {
                    robotLocation = { x: robotLocation.x, y: robotLocation.y + 1 };
                }                
                break;
            case '>':
                // east
                if (i % 2 == 0) {
                    santaLocation = { x: santaLocation.x + 1, y: santaLocation.y };
                } else {
                    robotLocation = { x: robotLocation.x + 1, y: robotLocation.y };
                }                
                break;
            case 'v':
                // south 
                if (i % 2 == 0) {
                    santaLocation = { x: santaLocation.x, y: santaLocation.y - 1 };
                } else {
                    robotLocation = { x: robotLocation.x, y: robotLocation.y - 1 };
                }                
                break;
            case '<':
                // west
                if (i % 2 == 0) {
                    santaLocation = { x: santaLocation.x - 1, y: santaLocation.y };
                } else {
                    robotLocation = { x: robotLocation.x - 1, y: robotLocation.y };
                }
                
                break;
        }
        if (i % 2 == 0) {
            santaLocations.push(santaLocation);
        } else {
            robotLocations.push(robotLocation);
        }      
    }
    var locations = santaLocations.concat(robotLocations);
    

    var locs = _.uniq(locations, false, function (loc) {
        // comparitor string for _uniq
        return 'x-' + loc.x + '-y-' + loc.y;
    });
    return locs.length;
};

fs.readFile('input.txt', { encoding: 'utf8' }, function (err, data) {
    var soloHouses = calculateSoloHouses(data);
    var roboHouses = calculateRoboHouses(data);
    
    console.log('Santa Visited ' + soloHouses + ' houses solo.');
    console.log('Santa Visited ' + roboHouses + ' houses with his robot.');
    console.log('Press any key to continue...');
    
    process.stdin.setRawMode(true);
    process.stdin.resume();
    process.stdin.on('data', process.exit.bind(process, 0));
});
