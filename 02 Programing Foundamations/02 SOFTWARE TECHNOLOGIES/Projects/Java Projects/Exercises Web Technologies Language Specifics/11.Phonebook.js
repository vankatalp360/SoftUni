function manipulatePhoneBook(input) {
    let i=0;
    let phoneBook = [];
    while(input[i]!="END")
    {
        let words = input[i].split(' ');
        if (words[0]==="A")
        {
            let name = words[1];
            let number = words[2];
           phoneBook[name]=number;
        }
        else
        {
            let name = words[1];
            if (phoneBook[name]===undefined)
            {
                console.log(`Contact ${name} does not exist.`);
            }
            else
            {
                console.log(`${name} -> ${phoneBook[name]}`);
            }
        }
        i++;
    }
}

let text = [ 'A Nakov 0888080808','S Mariika' , 'S Nakov' , 'END'];

manipulatePhoneBook(text);