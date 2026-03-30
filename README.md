# VR Educational Experience

This is an early-stage VR project developed for the Turkish Ministry of Education's ETKİM initiative.

The project aims to provide interactive, immersive experiences that teach social values, public behavior, and support career awareness through engaging VR mini-scenarios.

### Current Features
- XR-supported Unity scene with immersive player control
- Dialogue-based bullying scenario with interactive choices
- Police arrival and feedback based on user decisions
- Visual storytelling with animated events

### Planned Features
- Open-world navigation
- Multiple educational mini-games
- Modules on social rules, empathy, and career exploration
- Voice narration and dynamic feedback

> This is a work-in-progress educational VR game developed by university students to support values education in an engaging and modern way.

---

🎓 Developed with Unity 6.1 + OpenXR  
🎯 Goal: Support student development through interactive VR storytelling.



## Backend & Database Setup

To run this project locally:

1. Install PostgreSQL

2. Create a database:
   UnityVRDecisionSave

3. Run the following SQL:

CREATE TABLE user_choices (
id SERIAL PRIMARY KEY,
user_id VARCHAR(100),
event_id VARCHAR(100),
selected_option INT,
selected_text VARCHAR(255),
created_at TIMESTAMP DEFAULT NOW(),
UNIQUE(user_id, event_id)
);

4. Open the backend project and update the connection string:

Host=localhost;Port=5432;Username=postgres;Password=YOUR_PASSWORD;Database=UnityVRDecisionSave

5. Run the API (Visual Studio)

6. Run the Unity project

API endpoint used:
http://localhost:5136/api/Choices
