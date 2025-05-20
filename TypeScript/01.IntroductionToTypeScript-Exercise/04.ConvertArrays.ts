function convertArrays(words: string[]) : [string, number] {
  const text = words.join('');

  return [text, text.length]
}