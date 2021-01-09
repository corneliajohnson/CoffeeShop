const url = "https://localhost:5001/api/beanvariety/";

const button = document.querySelector("#run-button");
const beans = document.querySelector("#bean-varieties");
let text = "";

button.addEventListener("click", () => {
    getAllBeanVarieties()
        .then(beanVarieties => {
          beanVarieties.map(bean =>
              text += `
            <div>
                <h4>${bean.name}</h4>
                <p>${bean.region}</p>
                <p>${bean.notes}</p>
            </div>`)
        })
    beans.innerHTML = text;
});



function getAllBeanVarieties() {
    return fetch(url).then(resp => resp.json());
}
