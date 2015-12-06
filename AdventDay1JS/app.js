var fs = require('fs');
var readline = require('readline');

var housesDay1 = function(input) {
	var count = 0;
	for (var i = 0; i < input.length; i++) {
		var currentChar = input[i];
		if (currentChar === '(') {
			count++;
		}
		else {
			count--;
		}
	}
	
	return count;
};

var housesDay2 = function(input) {
	var count = 0;
	for (var i = 0; i < input.length; i++) {
		var currentChar = input[i];
		if (currentChar === '(') {
			count++;
		}
		else {
			count--;
		}
		if (count < 0) {			
			return i + 1;
		}
	}
	return -1;
};

console.log('fdsfs');
fs.readFile('input.txt', { encoding: 'utf8' }, function (err, data) {
	if (err) throw err;

	console.log('Ending Floor: ' + housesDay1(data));
	console.log('Basement Move: ' + housesDay2(data));
	console.log('Press any key to continue...');
	
	process.stdin.setRawMode(true);
	process.stdin.resume();
	process.stdin.on('data', process.exit.bind(process, 0));
});