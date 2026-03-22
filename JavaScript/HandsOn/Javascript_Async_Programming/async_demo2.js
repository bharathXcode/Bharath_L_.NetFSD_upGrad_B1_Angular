function getData() {
  return new Promise(resolve => {
    setTimeout(() => resolve("Data received"), 2000);
  });
}

async function displayData() {
  let data = await getData();
  console.log(data);
}

displayData();