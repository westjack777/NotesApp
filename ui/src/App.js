import "./App.css";
import { Component } from "react";

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      notes: [],
    };
  }

  // Ensure the URL uses HTTPS and matches the backend URL with the correct port
  API_URL = "https://localhost:7113/";

  componentDidMount() {
    this.refreshNotes();
  }

  // Fetch all notes from the HTTPS-enabled API
  async refreshNotes() {
    try {
      const response = await fetch(this.API_URL + "GetNotes", {
        method: "GET",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
        },
      });
      if (!response.ok) throw new Error("Failed to fetch notes");
      const data = await response.json();
      this.setState({ notes: data });
    } catch (error) {
      console.error("Error fetching notes:", error);
    }
  }

  // Add a new note securely
  async addClick() {
    const newNotes = document.getElementById("newNotes").value;
    const note = { description: newNotes };

    try {
      const response = await fetch(this.API_URL + "AddNotes", {
        method: "POST",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(note),
      });
      if (!response.ok) throw new Error("Failed to add note");
      document.getElementById("newNotes").value = ""; // Clear input field after adding
      await this.refreshNotes(); // Refresh notes after adding
      alert("Note added successfully");
    } catch (error) {
      console.error("Error adding note:", error);
    }
  }

  // Delete a note by ID
  async deleteClick(id) {
    try {
      const response = await fetch(this.API_URL + `DeleteNotes?id=${id}`, {
        method: "DELETE",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
        },
      });
      if (!response.ok) throw new Error("Failed to delete note");
      await this.refreshNotes(); // Refresh notes after deletion
      alert("Note deleted successfully");
    } catch (error) {
      console.error("Error deleting note:", error);
    }
  }

  render() {
    const { notes } = this.state;
    return (
      <div className="App">
        <h2>ToDo App</h2>
        <input id="newNotes" placeholder="Enter a new note" />
        &nbsp;
        <button onClick={() => this.addClick()}>Add Note</button>
        <div>
          {notes.map((note) => (
            <div key={note.id}>
              <p>
                <b>* {note.description}</b>&nbsp;
                <button onClick={() => this.deleteClick(note.id)}>
                  Delete
                </button>
              </p>
            </div>
          ))}
        </div>
      </div>
    );
  }
}

export default App;
