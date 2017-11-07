const Film = require('../models/Film');

module.exports = {
    index: (req, res) => {
        Film.find().then(films => {
            res.render('film/index', {
                'films': films
            });
        }).catch(err => {
            res.render('film/index', {error: err.message})
        });
    },
    createGet: (req, res) => {
        res.render('film/create');
    },
    createPost: (req, res) => {
        const filmArgs = req.body;
        let errorMsg = '';
        if (!filmArgs.name) {
            errorMsg = 'Invalid name! Please fill correct name!';
        } else if (!filmArgs.genre) {
            errorMsg = 'Invalid genre! Please fill genre!';
        }
        else if (!filmArgs.director) {
            errorMsg = 'Invalid director! Please fill director!';
        }
        else if (!filmArgs.year) {
            errorMsg = 'Invalid year! Please fill year!';
        }
        if (errorMsg) {
            res.render('film/create', {error: errorMsg});
            return;
        }
        Film.create(filmArgs).then(film => {
            res.redirect('/');
        }).catch(err => {
            filmArgs.error = 'Can not create film! Invalid film! Please full fill the form!';
            res.render('film/create', filmArgs);
        });
    },
    editGet: (req, res) => {
        let id = req.params.id;
        Film.findById(id).then(film => {
            if (!film) {
                res.redirect('/');
                return;
            }
            res.render('film/edit', film);
        }).catch(err => {
            return res.redirect('/')
        });
    },
    editPost: (req, res) => {
        let id = req.params.id;
        let film = req.body;
        Film.findByIdAndUpdate(id, film, {runValidators: true}).then(films => {
            res.redirect('/');
        }).catch(err => {
            film.id = id;
            film.error = 'Can not edit such film! Invalid film!';
            return res.render('film/edit', film);
        });
    },
    deleteGet: (req, res) => {
        let id = req.params.id;
        Film.findById(id).then(film => {
            if (!film) {
                res.redirect('/');
                return;
            }
            res.render('film/delete', film);
        }).catch(err => {
            return res.redirect('/');
        });
    },
    deletePost: (req, res) => {
        let id = req.params.id;
        let film = req.body;

        Film.findByIdAndRemove(id).then(films => {
            res.redirect('/');
        }).catch(err => {
            film.id = id;
            film.errorMsg = 'Can not delete such film! Invalid film!';
            return res.render('film/delete', film);
        });
    }
};