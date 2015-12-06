var fs = require('fs');
var readline = require('readline');

var calculateWrapping = function (input) {
    var returnObj = {
        paper: 0,
        ribbon: 0
    };

    var lineArray = input.split('\n');
    
    for (var i=0; i<lineArray.length; i++) {
        var boxArray = lineArray[i].split('x');

        var sideArea = [];
        sideArea[0] = boxArray[0] * boxArray[1];
        sideArea[1] = boxArray[0] * boxArray[2];
        sideArea[2] = boxArray[1] * boxArray[2];

        var sidePerimeter = [];
        sidePerimeter[0] = 2 * boxArray[0] + 2 * boxArray[1];
        sidePerimeter[1] = 2 * boxArray[0] + 2 * boxArray[2];
        sidePerimeter[2] = 2 * boxArray[1] + 2 * boxArray[2];

        var presentVolume = boxArray[0] * boxArray[1] * boxArray[2];

        sideArea.sort(function (a, b) {
            return a - b;
        });
        sidePerimeter.sort(function (a, b) {
            return a - b;
        });
        
        var sqFt = 2 * (boxArray[0] * boxArray[1]) + 2 * (boxArray[1] * boxArray[2]) + 2 * (boxArray[2] * boxArray[0]) + sideArea[0];
        var ribbonLength = sidePerimeter[0] + presentVolume;

        returnObj.paper += sqFt;
        returnObj.ribbon += ribbonLength;
    }

    return returnObj;
};

fs.readFile('input.txt', { encoding: 'utf8' }, function (err, data) {
    var wrapping = calculateWrapping(data);
    
    console.log('The total sqft was ' + wrapping.paper);
    console.log('The total ribbon was ' + wrapping.ribbon);
    console.log('Press any key to continue...');
    
    process.stdin.setRawMode(true);
    process.stdin.resume();
    process.stdin.on('data', process.exit.bind(process, 0));
});
