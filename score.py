import json
import joblib
import pandas as pd
import numpy as np
import os

def init():
    global model

    model_dir = os.getenv("AZUREML_MODEL_DIR", ".")
    model_path = os.path.join(model_dir, "student_g3_model.pkl")

    model = joblib.load(model_path)

def run(raw_data):
    try:
        data = json.loads(raw_data)

        if isinstance(data, dict) and "data" in data:
            data = data["data"]

        df = pd.DataFrame([data])

        prediction = model.predict(df)
        return prediction.tolist()

    except Exception as e:
        return {"error": str(e)}
