export async function downloadFileFromStream(fileName, contentStreamReference) {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    
    let url = URL.createObjectURL(blob);

    // Create a link element
    const link = document.createElement('a');
    link.href = url;
    link.download = fileName; // Set the filename

    // Simulate a click on the link to trigger the download
    link.click();
    link.remove();

    URL.revokeObjectURL(url);
}