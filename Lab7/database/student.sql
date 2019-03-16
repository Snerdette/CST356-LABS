CREATE TABLE student (
	student_id SERIAL PRIMARY KEY,
	email_address VARCHAR(64) NOT NULL,
	person_id INTEGER NOT NULL,
	FOREIGN KEY (person_id) REFERENCES person (person_id) ON DELETE CASCADE
);