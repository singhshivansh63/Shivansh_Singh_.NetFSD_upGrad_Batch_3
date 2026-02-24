const studentMarks = [85, 72, 90, 59, 58, 74];

 
const calculateTotal = (marks) => 
    marks.reduce((sum, mark) => sum + mark, 0);

 
const calculateAverage = (marks) => 
    calculateTotal(marks) / marks.length;

 
const getResult = (average) => 
    average >= 60 ? "PASS ✅" : "FAIL ❌";
 
export const analyzeMarks = () => {

    const total = calculateTotal(studentMarks);
    const average = calculateAverage(studentMarks);
    const result = getResult(average);
    const processedMarks = studentMarks.map(mark => mark);
    const outputText = `
Student Marks: ${processedMarks.join(", ")}

Total Marks: ${total}

Average Marks: ${average.toFixed(2)}

Final Result: ${result}
`;

    console.log(outputText);

    document.getElementById("output").textContent = outputText;
};
 
window.analyzeMarks = analyzeMarks;