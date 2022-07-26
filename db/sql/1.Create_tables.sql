-- Создание таблицы с кодами диагнозов согласно МКБ-10
CREATE TABLE IF NOT EXISTS Diagnoses (
  icd10code VARCHAR(36)  PRIMARY KEY,
  name      VARCHAR(512) NOT NULL
);

-- Создание таблицы с пациентами
CREATE TABLE IF NOT EXISTS Patients (
  id         VARCHAR(36) PRIMARY KEY,
  lastname   VARCHAR(50) NOT NULL,
  firstname  VARCHAR(50) NOT NULL,
  middlename VARCHAR(50) NOT NULL,
  birthdate  DATE        NOT NULL,
  phone      VARCHAR(15) NOT NULL
);

-- Создание таблицы с посещениями
CREATE TABLE IF NOT EXISTS Receptions (
  id           VARCHAR(36) PRIMARY KEY,
  date         TIMESTAMP   NOT NULL,
  diagnosis_id VARCHAR(36) NOT NULL REFERENCES Diagnoses(icd10code),
  patient_id   VARCHAR(36) NOT NULL REFERENCES Patients(id)
);
