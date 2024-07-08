import tkinter as tk
from tkinter import ttk, messagebox
import threading
import time
import json
import os
import matplotlib.pyplot as plt
from playsound import playsound

class WorkoutApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Workout Timer")
        self.root.geometry("400x800")
        self.current_exercise_index = 0
        self.current_set_index = 0
        self.reps_var = tk.StringVar()
        self.workout_log = []
        self.paused = False
        self.remaining_time = 0
        self.dark_mode = False

        self.load_workout_routine()
        self.load_workout_log()
        self.create_widgets()

    def load_workout_routine(self):
        try:
            with open("workout_routine.json", "r") as routine_file:
                self.workout_routine = json.load(routine_file)
        except FileNotFoundError:
            self.workout_routine = [
                {"name": "Warm up set", "sets": 1, "reps": [6], "rest": [120], "weight": [70]},
                {"name": "Lat Pull Down", "sets": 3, "reps": [4, 6, 8], "rest": [120, 120, 120], "weight": [70, 70, 70]},
                {"name": "Warm-up sets", "sets": 2, "reps": [6, 4], "rest": [120, 240], "weight": [10, 15]},
                {"name": "Standing Barbell Press", "sets": 3, "reps": [4, 6, 8], "rest": [240, 240, 240], "weight": [70, 70, 70]},
                {"name": "Cable Rows", "sets": 5, "reps": [12, 3, 3, 3, 3], "rest": [15, 15, 15, 15, 15], "weight": [70, 70, 70, 70, 70]},
                {"name": "Bent Over Dumbbell Flyes", "sets": 5, "reps": [12, 3, 3, 3, 3], "rest": [15, 15, 15, 15, 15], "weight": [70, 70, 70, 70, 70]},
                {"name": "Leaning In Lateral Raises", "sets": 5, "reps": [12, 3, 3, 3, 3], "rest": [10, 10, 10, 10, 10], "weight": [70, 70, 70, 70, 70]}
            ]

    def load_workout_log(self):
        if os.path.exists("workout_log.json"):
            with open("workout_log.json", "r") as log_file:
                self.workout_log = json.load(log_file)

    def create_widgets(self):
        self.exercise_label = tk.Label(self.root, text="", font=("Helvetica", 18))
        self.exercise_label.pack(pady=10)

        self.sets_label = tk.Label(self.root, text="", font=("Helvetica", 14))
        self.sets_label.pack(pady=5)

        self.reps_entry = tk.Entry(self.root, textvariable=self.reps_var, font=("Helvetica", 14))
        self.reps_entry.pack(pady=10)

        self.submit_button = tk.Button(self.root, text="Submit Reps", command=self.submit_reps, font=("Helvetica", 14))
        self.submit_button.pack(pady=10)

        self.timer_label = tk.Label(self.root, text="", font=("Helvetica", 24))
        self.timer_label.pack(pady=10)

        self.progress = ttk.Progressbar(self.root, orient="horizontal", length=300, mode="determinate")
        self.progress.pack(pady=10)

        self.log_text = tk.Text(self.root, height=10, font=("Helvetica", 12))
        self.log_text.pack(pady=20)
        self.log_text.config(state=tk.DISABLED)

        self.history_button = tk.Button(self.root, text="Workout History", command=self.show_history, font=("Helvetica", 14))
        self.history_button.pack(pady=5)

        self.progress_button = tk.Button(self.root, text="Show Progress", command=self.show_progress, font=("Helvetica", 14))
        self.progress_button.pack(pady=5)

        self.adjust_timer_button = tk.Button(self.root, text="Adjust Timer", command=self.adjust_timer, font=("Helvetica", 14))
        self.adjust_timer_button.pack(pady=5)

        self.pause_button = tk.Button(self.root, text="Pause Timer", command=self.pause_timer, font=("Helvetica", 14))
        self.pause_button.pack(pady=5)

        self.summary_button = tk.Button(self.root, text="Workout Summary", command=self.show_summary, font=("Helvetica", 14))
        self.summary_button.pack(pady=5)

        self.dark_mode_button = tk.Button(self.root, text="Toggle Dark Mode", command=self.toggle_dark_mode, font=("Helvetica", 14))
        self.dark_mode_button.pack(pady=5)

        self.update_exercise()

    def update_exercise(self):
        if self.current_exercise_index < len(self.workout_routine):
            exercise = self.workout_routine[self.current_exercise_index]
            exercise_name = exercise["name"]
            current_set = self.current_set_index + 1
            total_sets = exercise["sets"]
            self.exercise_label.config(text=f"{exercise_name} - Set {current_set}/{total_sets}")
            self.sets_label.config(text=f"Reps: {exercise['reps'][self.current_set_index]}, Weight: {exercise['weight'][self.current_set_index]} lb")
        else:
            self.exercise_label.config(text="Workout Complete!")
            self.sets_label.config(text="")
            self.submit_button.config(state=tk.DISABLED)

    def submit_reps(self):
        reps = self.reps_var.get()
        if reps.isdigit():
            self.reps_var.set("")
            self.log_workout(reps)
            self.start_rest_timer()
        else:
            messagebox.showerror("Invalid input", "Please enter a valid number of reps.")

    def start_rest_timer(self):
        if not self.paused:
            exercise = self.workout_routine[self.current_exercise_index]
            self.remaining_time = exercise["rest"][self.current_set_index]
            self.progress["maximum"] = self.remaining_time
            self.progress["value"] = 0
        self.timer_label.config(text=f"Resting for {self.remaining_time} seconds")
        self.pause_button.config(text="Pause Timer")
        self.paused = False
        threading.Thread(target=self.countdown).start()

    def countdown(self):
        while self.remaining_time > 0 and not self.paused:
            time.sleep(1)
            self.remaining_time -= 1
            self.progress["value"] += 1
            self.timer_label.config(text=f"Resting for {self.remaining_time} seconds")
        if self.remaining_time == 0:
            self.timer_label.config(text="")
            playsound("sound.wav")
            self.current_set_index += 1
            exercise = self.workout_routine[self.current_exercise_index]
            if self.current_set_index >= exercise["sets"]:
                self.current_exercise_index += 1
                self.current_set_index = 0
            self.update_exercise()

    def log_workout(self, reps):
        exercise = self.workout_routine[self.current_exercise_index]
        current_set = self.current_set_index + 1
        log_entry = {
            "exercise": exercise["name"],
            "set": current_set,
            "reps": reps,
            "weight": exercise["weight"][self.current_set_index]
        }
        self.workout_log.append(log_entry)
        self.update_log_display()
        with open("workout_log.json", "w") as log_file:
            json.dump(self.workout_log, log_file, indent=4)

    def update_log_display(self):
        self.log_text.config(state=tk.NORMAL)
        self.log_text.delete(1.0, tk.END)
        for entry in self.workout_log:
            log_entry_text = f"Exercise: {entry['exercise']}, Set: {entry['set']}, Reps: {entry['reps']}, Weight: {entry['weight']} lb\n"
            self.log_text.insert(tk.END, log_entry_text)
        self.log_text.config(state=tk.DISABLED)

    def show_history(self):
        history_window = tk.Toplevel(self.root)
        history_window.title("Workout History")
        history_window.geometry("400x600")
        history_text = tk.Text(history_window, font=("Helvetica", 12))
        history_text.pack(pady=10)
        history_text.config(state=tk.NORMAL)
        for entry in self.workout_log:
            log_entry_text = f"Exercise: {entry['exercise']}, Set: {entry['set']}, Reps: {entry['reps']}, Weight: {entry['weight']} lb\n"
            history_text.insert(tk.END, log_entry_text)
        history_text.config(state=tk.DISABLED)

    def show_progress(self):
        if not self.workout_log:
            messagebox.showinfo("No Data", "No workout data to display.")
            return

        exercises = list(set(entry["exercise"] for entry in self.workout_log))
        exercise_data = {exercise: {"sets": [], "reps": [], "weights": []} for exercise in exercises}

        for entry in self.workout_log:
            exercise = entry["exercise"]
            exercise_data[exercise]["sets"].append(entry["set"])
            exercise_data[exercise]["reps"].append(entry["reps"])
            exercise_data[exercise]["weights"].append(entry["weight"])

        for exercise, data in exercise_data.items():
            plt.figure(figsize=(10, 5))
            plt.plot(data["sets"], data["reps"], marker='o', label='Reps')
            plt.plot(data["sets"], data["weights"], marker='x', label='Weight (lb)')
            plt.title(f"Progress for {exercise}")
            plt.xlabel("Set")
            plt.ylabel("Reps / Weight (lb)")
            plt.legend()
            plt.grid(True)
            plt.show()

    def adjust_timer(self):
        def set_timer():
            try:
                new_time = int(timer_entry.get())
                if new_time <= 0:
                    raise ValueError
                self.remaining_time = new_time
                self.progress["maximum"] = new_time
                adjust_window.destroy()
                self.start_rest_timer()
            except ValueError:
                messagebox.showerror("Invalid Input", "Please enter a valid positive integer.")

        adjust_window = tk.Toplevel(self.root)
        adjust_window.title("Adjust Timer")
        adjust_window.geometry("300x200")

        timer_label = tk.Label(adjust_window, text="Enter new rest time in seconds:", font=("Helvetica", 14))
        timer_label.pack(pady=10)

        timer_entry = tk.Entry(adjust_window, font=("Helvetica", 14))
        timer_entry.pack(pady=10)

        set_button = tk.Button(adjust_window, text="Set Timer", command=set_timer, font=("Helvetica", 14))
        set_button.pack(pady=10)

    def pause_timer(self):
        if not self.paused:
            self.paused = True
            self.pause_button.config(text="Resume Timer")
        else:
            self.paused = False
            self.pause_button.config(text="Pause Timer")
            self.start_rest_timer()

    def show_summary(self):
        summary_window = tk.Toplevel(self.root)
        summary_window.title("Workout Summary")
        summary_window.geometry("400x600")
        summary_text = tk.Text(summary_window, font=("Helvetica", 12))
        summary_text.pack(pady=10)
        summary_text.config(state=tk.NORMAL)
        total_sets = len(self.workout_log)
        total_reps = sum(int(entry["reps"]) for entry in self.workout_log)
        total_weight = sum(int(entry["weight"]) for entry in self.workout_log)
        summary_text.insert(tk.END, f"Total Sets: {total_sets}\n")
        summary_text.insert(tk.END, f"Total Reps: {total_reps}\n")
        summary_text.insert(tk.END, f"Total Weight Lifted: {total_weight} lb\n")
        summary_text.config(state=tk.DISABLED)

    def toggle_dark_mode(self):
        self.dark_mode = not self.dark_mode
        bg_color = "black" if self.dark_mode else "white"
        fg_color = "white" if self.dark_mode else "black"
        self.root.config(bg=bg_color)
        for widget in self.root.winfo_children():
            widget.config(bg=bg_color, fg=fg_color)

if __name__ == "__main__":
    root = tk.Tk()
    app = WorkoutApp(root)
    root.mainloop()
