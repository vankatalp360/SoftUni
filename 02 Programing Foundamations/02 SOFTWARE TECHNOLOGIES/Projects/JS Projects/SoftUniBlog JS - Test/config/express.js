var express = require('express');
var path = require('path');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');
var session = require('express-session');
var passport = require('passport');
module.exports = (app, config) =>{
    //View engine setup
    app.set('views',path.join(config.rootFolder,'\views'));
    app.set('view engine', 'hbs');


    //This set up which is the parser for the request's data
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({extended:true}));

    //We will use cookies.
    app.use(cookieParser());

    //Session is storage for cookies, which will be de/encrypted with the 'secret' key.
    app.use(session({secret:'s3cr3t5tr1ng',resave:false,saveUninitialized:false}));

    //For user validation we will use possport module.
    app.use(passport.initialize());
    app.use(passport.session());

    //This makes the content in the "public" folder accessible for every user.
    app.use(express.static(path.join(config.rootFolder,'public')));
};
