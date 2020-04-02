function extractFile(input) {
    let lastBackslashIndex = input.lastIndexOf("\\");
    let lastPointIndex = input.lastIndexOf(".");

    let name = input.substring(lastBackslashIndex + 1, lastPointIndex);
    let extension = input.substring(lastPointIndex + 1);
    console.log(`File name: ${name}`)
    console.log(`File extension: ${extension}`)
}

extractFile('C:\\Internal\\training-internal\\Template.pptx');