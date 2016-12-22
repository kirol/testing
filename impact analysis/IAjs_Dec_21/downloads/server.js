/**
 * http://usejsdoc.org/
 */
var http = require('http');
var fs = require('fs');
var formidable = require("formidable");
var util = require('util');

var server = http.createServer(function (req, res) {
	displayForm(res);
    if (req.method.toLowerCase() == 'get') {
        
    } else if (req.method.toLowerCase() == 'post') {
    	writeToJson(req,res);
    }

});

function displayForm(res) {
    fs.readFile('views/index', function (err, data) {
        res.writeHead(200, {
            'Content-Type': 'text/html',
                'Content-Length': data.length
        });
        res.write(data);
        res.end();
    });
}

function writeToJson(req,res){
	var form = new formidable.IncomingForm();
	form.parse(req, function (err, fields, files) {
		fs = require('fs');
		fs.writeFile('information.json', JSON.stringify(fields), function (err) {
		  if (err) return console.log(err);
		  console.log('information.json');
		});
    });
}

server.listen(3000);
console.log("server listening on 1185");