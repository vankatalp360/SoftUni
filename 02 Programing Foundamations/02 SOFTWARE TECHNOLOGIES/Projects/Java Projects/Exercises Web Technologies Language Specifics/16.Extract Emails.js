function extractEmails(input) {
    let text = input[0];

        let pattern = new RegExp(/[A-Za-z0-9]+[.\-_]*[A-Za-z0-9]+@[A-Za-z\-]+(\.[A-Za-z\-]+)+/gm);

    let match;
    while (match = pattern.exec(text)){
        console.log(match[0]);
    }
}

let text = [ 'Just send email to s.miller@mit.edu and j.hopking@york.ac.uk for more information.','end' ];

extractEmails(text);