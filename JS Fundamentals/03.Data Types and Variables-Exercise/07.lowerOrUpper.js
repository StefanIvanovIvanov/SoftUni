function lowerToUpper(inputChar) {
   let num = inputChar.charCodeAt()
   num > 96 ? console.log(`lower-case`) : console.log(`upper-case`)
}

lowerToUpper('f');