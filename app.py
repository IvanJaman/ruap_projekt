from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
import joblib
import pandas as pd

app = FastAPI(title="Student Grade Prediction API")

app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

model = joblib.load("student_g3_model.pkl")

@app.post("/predict")
def predict(data: dict):
    """
    Receives student data as JSON and returns predicted final grade (G3).
    """
    df = pd.DataFrame([data])
    prediction = model.predict(df)
    return {"prediction": float(prediction[0])}
