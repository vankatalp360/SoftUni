function extractWord(input) {
    let word = input[0];
    let text = input[1];

    let pattern = new RegExp(`(([^?.!]+)[^A-Za-z]${word}[^A-Za-z]([^?.!]+))([.?!])`,'g');

    let match;
    while (match = pattern.exec(text)){
        console.log(match[1]);
    }
}

let text = [ 'to','TODO. TO DO. To Do. Welcome to SoftUni! You will learn programming, algorithms, problem solving and software technologies. You need to allocate for study 20-30 hours weekly. What to do? Good luck! Tell me what to do! I am fan of Motorhead. To be or not to be - that is the question. TO DO OR NOT? Tell me what TO do! Make a TODO list (todo list). Make a todo. Come today. I like computers (to play). Can I have a TODO list /to do list/?' ];

extractWord(text);