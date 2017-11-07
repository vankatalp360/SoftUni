const Task = require('mongoose').model('Task');

module.exports = {
    index: (req, res) => {
        Task.find().then(tasks => {
            res.render('task/index', {
                'openTasks': tasks.filter(task => task.status === "Open"),
                'inProgressTasks': tasks.filter(task => task.status === "In Progress"),
                'finishedTasks': tasks.filter(task => task.status === "Finished")
            });
        }).catch(err => {
            res.render('task/index', {error: err.message})
        });
    },
    createGet: (req, res) => {
        res.render('task/create');
    },
    createPost: (req, res) => {
        const taskArgs = req.body;
        let errorMsg = '';
        if (!taskArgs.title) {
            errorMsg = 'Invalid title! Please fill correct title!';
        } else if (!taskArgs.status) {
            errorMsg = 'Invalid status! Please fill status!';
        }
        if (errorMsg) {
            res.render('task/create', {error: errorMsg});
            return;
        }
        Task.create(taskArgs).then(task => {
            res.redirect('/');
        }).catch(err => {
            taskArgs.error = 'Can not create task! Invalid task! Please full fill the form!';
            res.render('tack/create',  taskArgs);
        });
    },
    editGet: (req, res) => {
        let id = req.params.id;
        // if (!id) {
        //     res.redirect('/');
        //     return;
        // }

        Task.findById(id).then(task => {
            if (!task) {
                res.redirect('/');
                return;
            }
            res.render('task/edit', task);
        }).catch(err => {
            return res.redirect('/')
        });
    },
    editPost: (req, res) => {
        let id = req.params.id;
        let task = req.body;

        // if (!id) {
        //     res.redirect('/');
        //     return;
        // }

        Task.findByIdAndUpdate(id, task, {runValidators: true}).then(tasks => {
            res.redirect('/');
        }).catch(err => {
            task.id = id;
            task.error = 'Can not edit such task! Invalid task!';
            return res.render('task/edit', task);
        });
    }
};