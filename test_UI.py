import tkinter as tk
from tkinter import filedialog
import os
import re
import json

def select_folder():
    folder_selected = filedialog.askdirectory()
    folder_label.config(text=folder_selected)

def compare_files(file1, file2):
    try:
        with open(file1, 'r') as f1, open(file2, 'r') as f2:
            data1 = json.load(f1)
            data2 = json.load(f2)
        # 比较文件内容，这里简单比较数据是否相等
        if data1 == data2:
            print(f"Files {file1} and {file2} are identical.")
        else:
            print(f"Files {file1} and {file2} are different.")
    except Exception as e:
        print(f"Error comparing files {file1} and {file2}: {e}")

def run_comparison():
    folder = folder_label.cget("text")

    if not os.path.isdir(folder):
        print("Invalid folder.")
        return

    mountain_out_files = []
    mountain_data_files = []

    for root, dirs, files in os.walk(folder):
        for file in files:
            if re.match(r"mountain_.*_out\.json", file):
                mountain_out_files.append(os.path.join(root, file))
            elif re.match(r"mountainData.*\.json", file):
                mountain_data_files.append(os.path.join(root, file))

    for out_file in mountain_out_files:
        for data_file in mountain_data_files:
            compare_files(out_file, data_file)


root = tk.Tk()
root.geometry("300x200")
root.title("导入导出json对比(批量)")

# Folder selection
folder_frame = tk.Frame(root)
folder_frame.pack(pady=10)

folder_button = tk.Button(folder_frame, text="选择文件夹", command=select_folder)
folder_button.pack(side="left", padx=10)

folder_label = tk.Label(folder_frame, text="未选择文件夹")
folder_label.pack(side="left", padx=10)

# Run comparison button
compare_button = tk.Button(root, text="运行比较", command=run_comparison)
compare_button.pack(pady=20)

root.mainloop()