var express = require('express');
var passport = require('passport');
var FacebookStrategy = require('passport-facebook').Strategy;
var engine = require('ejs-locals');
var path = require('path');
var favicon = require('serve-favicon');
var logger = require('morgan');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');

var routes = require('./routes/index');
var users = require('./routes/users');
var create = require('./routes/create');

var config = require('./config');

var app = express();

// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.engine('ejs', engine);
app.set('view engine', 'ejs');

// uncomment after placing your favicon in /public
//app.use(favicon(__dirname + '/public/favicon.ico'));
app.use(logger('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));
app.use(express.static(path.join(__dirname, 'sources')));

app.use(express.static(path.join(__dirname, 'gojs')));

// config facebook login
app.use(passport.initialize());
app.use(passport.session());
// Use the FacebookStrategy within Passport.
//   Strategies in Passport require a `verify` function, which accept
//   credentials (in this case, an accessToken, refreshToken, and Facebook
//   profile), and invoke a callback with a user object.
passport.use(new FacebookStrategy({
        clientID: config.facebook.application_id,
        clientSecret: config.facebook.application_secret,
        callbackURL: "http://www.figueiredos.com:3000/auth/facebook/callback"
    },
    function(accessToken, refreshToken, profile, done) {
        // asynchronous verification, for effect...
        process.nextTick(function () {

            // To keep the example simple, the user's Facebook profile is returned to
            // represent the logged-in user.  In a typical application, you would want
            // to associate the Facebook account with a user record in your database,
            // and return that user instead.
            console.log( profile);
            return done(null, profile);
        });
    }
));

//process for javascript AJAX here
var bodyParser = require("body-parser");
app.use(bodyParser.urlencoded({extended : true}));
var urlencodedParser = bodyParser.urlencoded({ extended: false });

var jsonParser = bodyParser.json();
//app.use(express.static('public'));

//Ajax post process
/*app.post('/process_addmodule', jsonParser, function (req, res) {
	var jsonNode=req.body;
	console.log(req.body);
	res.end("OK");
});*/

//Ajax post process
app.post('/process_addnode', urlencodedParser, function (req, res) {
	var jsonNode=req.body;
	//console.log("new node= "+JSON.stringify(jsonNode));
	
	for (key in jsonNode){
		if (jsonNode[key]=="null"){
			jsonNode[key]=null;
		}
	}
	var fs = require('fs');
	var obj;
	var max=0;
	fs.readFile('sources/data/node_all.json', 'utf8', function (err, data) {
	  if (err) throw err;
	  obj = JSON.parse(data);
	  for (var key in obj) {
//		  console.log("key= "+key);
		  var keyInt= parseInt(key,10);
		  if (max<keyInt){
			  max=keyInt;
		  }
	  }
	  max=max+1;
	  //console.log("new node= "+JSON.stringify(jsonNode));
	  obj[max.toString()]=jsonNode; //POST data from client
	  //console.log("new data= "+JSON.stringify(obj));
	  fs = require('fs');
	  fs.writeFile('sources/data/node_all.json', JSON.stringify(obj,null,4), function (err) {
		  if (err) return console.log(err);
			console.log('sources/data/node_all.json');
	  });
	});
		
   res.end("OK");
});

app.post('/process_addlink',  function (req, res) {
	//console.log(req.body);
	var jsonStrings="";
	for (key in req.body){
		var jsonStrings=key;
		if (key!==''){
			break;
		}
	}
	console.log(jsonStrings);
	jsonLinks=JSON.parse(jsonStrings);
	var fs = require('fs');
	var obj;
	var max=0;
	//ADD link
	fs.readFile('sources/data/link_all.json', 'utf8', function (err, data) {
		  if (err) throw err;
		  obj = JSON.parse(data);
		  for (var key in obj) {
			  
			  var keyInt= parseInt(key,10);
			  if (max<keyInt){
				  max=keyInt;
			  }
		  }
		  max=max+1;
		  console.log("max= "+max.toString());
		  for (key1 in jsonLinks){
			  obj[max.toString()]=jsonLinks[key1];
			  console.log('Gi day ??: '+key1);
			  console.log(jsonLinks[key1]);
			  max+=1;
		  }
		  
		  fs = require('fs');
		  fs.writeFile('sources/data/link_all.json', JSON.stringify(obj,null,4), function (err) {
			  if (err) return console.log(err);
				console.log('sources/data/link_all.json');
		  });
		});
		
   res.end("OK");
});

//end of AJAX

app.get('/auth/facebook',
    passport.authenticate('facebook'));

app.get('/auth/facebook/callback',
    passport.authenticate('facebook', { failureRedirect: '/login' }),
    function(req, res) {
        // Successful authentication, redirect home.
        res.redirect('/');
    });

// Passport session setup.
//   To support persistent login sessions, Passport needs to be able to
//   serialize users into and deserialize users out of the session.  Typically,
//   this will be as simple as storing the user ID when serializing, and finding
//   the user by ID when deserializing.  However, since this example does not
//   have a database of user records, the complete Facebook profile is serialized
//   and deserialized.
passport.serializeUser(function(user, done) {
    done(null, user);
});

passport.deserializeUser(function(obj, done) {
    done(null, obj);
});

app.use('/home', routes);
app.use('/users', users);
app.use('/create', create);

// catch 404 and forward to error handler
app.use(function(req, res, next) {
    var err = new Error('Not Found');
    err.status = 404;
    next(err);
});

// error handlers

// development error handler
// will print stacktrace
if (app.get('env') === 'development') {
    app.use(function(err, req, res, next) {
        res.status(err.status || 500);
        res.render('error', {
            message: err.message,
            error: err
        });
    });
}

// production error handler
// no stacktraces leaked to user


/*app.post("/aa", function(request, response) {
    console.log(request.body.yourFieldName); 
    response.send("Message received.");
    response.end();
});*/

//app.listen(3000);

module.exports = app;
