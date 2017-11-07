function filterText(input) {
    let words = input[0].split(',').map(e => e.trim());
    let text = input[1];
    for(let word of words)
    {
        let replacementWord ='*'.repeat(word.length);
        let pattern = new RegExp(word, 'g');
        text=text.replace(pattern,replacementWord);
    }
    console.log(text);
}

let text = [ 'Linux, Windows'
    ,'It is not Linux, it is GNU/Linux. Linux is merely the kernel, while GNU adds the functionality. Therefore we owe it to them by calling the OS GNU/Linux! Sincerely, a Windows client' ];

filterText(text);