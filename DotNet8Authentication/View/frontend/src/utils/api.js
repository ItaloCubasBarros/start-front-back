//arquivo responsável por consumir a API
//será usado o axios ao invés do fetch
import axios from "axios"

export default axios.create({
    baseURL: 'https://localhost:7251'
})