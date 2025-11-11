# NBA Data Trend Analysis

![NBA Logo](https://img.shields.io/badge/NBA-Data%20Analysis-orange)
![Database](https://img.shields.io/badge/Database-Oracle%20SQL-red)

Martin Kent, Alex Vargas, Derek Meyer , Joseph Cuenco, Ethan Alexander

---

## Table of Contents

* [Overview](#overview)
* [Project Description](#project-description)
* [Repository Structure](#repository-structure)
* [Database Architecture](#database-architecture)
  * [Entity-Relationship Model](#entity-relationship-model)
  * [Relational Schema](#relational-schema)
  * [SQL Implementation](#sql-implementation)
* [Key Features & Queries](#key-features--queries)
* [Installation & Setup](#installation--setup)
* [Usage](#usage)
* [Project Deliverables](#project-deliverables)
* [Technologies Used](#technologies-used)
* [Team Members](#team-members)

---

## Overview

The **NBA Data Trend Analysis** project is a comprehensive database system designed for NBA fans, coaches, and league executives to explore and analyze basketball statistics. This database enables users to investigate offensive performance trends, player impacts on team success, and the historical evolution of the game through interactive visualizations and custom queries.

**Repository:** [https://github.com/martinkent2003/NBATrends](https://github.com/martinkent2003/NBATrends)

---

## Project Description

### Purpose

This database serves multiple audiences with data-driven insights:

* **Fans:** Support arguments with concrete statistical evidence and gain deeper insights into the intricacies of the game
* **Coaches:** Access comprehensive data for performance evaluation, opponent scouting, and strategic game planning
* **Analysts:** Track historical trends from the inaugural 1946-47 NBA season and predict future league developments
* **Researchers:** Evaluate player greatness contextually within their era and team environment

### Functionality

Users interact with the database through a web-based interface featuring:

* **Dynamic Query Form:** Input parameters including time ranges, team selections, player identification, and specific statistics
* **Predefined Graphs:** Quick access to commonly requested statistical trends
* **Interactive Visualizations:** Adjust parameters dynamically to refine analysis
* **Comprehensive Statistics:** Access to 65,700+ games and detailed player performance metrics

---

## Repository Structure

```
NBATrends/
│
├── deliverables/
│   ├── Deliverable_2.pdf    # ER Diagram & Conceptual Design
│   └── Deliverable_3.pdf    # SQL Implementation & Schemas
│
├── sql/
│   ├── create_tables.sql    # Table creation scripts
│   ├── load_data.sql        # Data loading scripts
│   └── queries.sql          # Example queries
│
├── docs/
│   ├── ER_Diagram.png       # Entity-Relationship Diagram
│   └── Schema_Design.pdf    # Database schema documentation
│
└── README.md                # This file
```

---

## Database Architecture

### Entity-Relationship Model

#### Core Entities

1. **Player** (4,815 records)
   * `person_id`, `first_name`, `last_name`, `is_active`
   * Basic identification for NBA athletes

2. **CommonPlayerInfo** (3,632 records)
   * Extended player statistics: `birthdate`, `school`, `country`, `height`, `weight`, `position`, `jersey`, `from_year`, `to_year`, `greatest_75_flag`, `d_league_flag`
   * Biographical data and career information

3. **Team** (30 records)
   * `team_id`, `full_name`, `abbreviation`, `nickname`, `year_founded`, `Facebook`, `Instagram`, `Twitter`
   * NBA team information and social media profiles

4. **Game** (65,700+ records)
   * Comprehensive game statistics including field goals, three-pointers, free throws, rebounds, assists, steals, blocks, turnovers
   * Supports both home and away team perspectives

5. **PlayerBoxScore** (Extensive records)
   * Individual player performance statistics per game
   * Detailed shooting percentages, rebounds, assists, and advanced metrics

6. **DraftHistory** (8,257 records)
   * `person_id`, `season`, `round_number`, `round_pick`, `overall_pick`, `team_id`, `organization`
   * Complete draft information for players

#### Key Relationships

* **Player-Has-CommonPlayerInfo** (1:1)
  * Participation: Player (Partial), CommonPlayerInfo (Total)
  * Optional additional information for players

* **Player-Has-DraftHistory** (1:1)
  * Participation: Player (Partial - some undrafted), DraftHistory (Total)
  * Draft records for eligible players

* **Player-Has-PlayerBoxScore** (1:N)
  * Participation: Player (Partial), PlayerBoxScore (Total)
  * Player statistics across multiple games

* **Team-Plays-Game** (N:M)
  * Cardinality: 2 teams per game
  * Participation: Both Total

* **CommonPlayerInfo-PlaysFor-Team** (N:1)
  * Players belong to teams

* **DraftHistory-DraftedBy-Team** (N:1)
  * Teams make multiple draft picks

### Relational Schema

#### Player Table

```sql
Player(person_id, isActive, lastName, firstName)
PRIMARY KEY: person_id
```

#### CommonPlayerInfo Table

```sql
CommonPlayerInfo(
    person_id, team_id, country, school, from_year, 
    position, weight, height, to_year, jerseyNum, 
    seasons, greatest_75_flag, d_league_flag, birthdate
)
PRIMARY KEY: person_id
FOREIGN KEY: team_id REFERENCES Team(team_id)
```

#### Team Table

```sql
Team(
    team_id, full_name, abbreviation, nickname, 
    year_founded, Facebook, Instagram, Twitter
)
PRIMARY KEY: team_id
```

#### Game Table

```sql
Game(
    game_id, season_id, team_id, home_away, season_type,
    field_goals_made, field_goals_attempted, field_goal_percentage,
    fg_threes_made, fg_threes_attempted, fg_threes_percentage,
    free_throws_made, free_throws_attempted, free_throw_percentage,
    offensive_rebounds, defensive_rebounds, assists, steals, 
    blocks, turnovers, personal_fouls, points, plus_minus
)
PRIMARY KEY: (game_id, team_id)
FOREIGN KEY: team_id REFERENCES Team(team_id)
```

#### PlayerBoxScore Table

```sql
PlayerBoxScore(
    season_id, player_id, team_id, game_id, win_loss, mins,
    field_goals_made, field_goals_attempted, field_goal_percentage,
    fg_threes_made, fg_threes_attempted, fg_threes_percentage,
    free_throws_made, free_throws_attempted, free_throw_percentage,
    offensive_rebounds, defensive_rebounds, rebounds, assists,
    steals, blocks, turnovers, personal_fouls, points, plus_minus
)
PRIMARY KEY: (player_id, game_id)
FOREIGN KEY: player_id REFERENCES Player(person_id)
FOREIGN KEY: (game_id, team_id) REFERENCES Game(game_id, team_id)
```

#### DraftHistory Table

```sql
DraftHistory(
    person_id, season_id, round_number, round_pick, 
    overall_pick, team_id, organization, organization_type, 
    player_profile_flag
)
PRIMARY KEY: person_id
FOREIGN KEY: person_id REFERENCES Player(person_id)
FOREIGN KEY: team_id REFERENCES Team(team_id)
```

### SQL Implementation

**Oracle SQL Developer Considerations:**

* Used `NUMBER(1)` instead of `BOOLEAN` for Oracle compatibility
* Applied `NOT NULL` constraints for essential attributes
* Implemented composite keys for Game and PlayerBoxScore tables
* Established foreign key relationships to maintain referential integrity
* Created indexes on frequently queried columns for performance optimization

---

## Key Features & Queries

### 1. Three-Point Shot Impact Analysis

**Query:** Analyze how three-point shooting has impacted NBA scoring output over time

```sql
-- Average game scores and three-point attempts over time
SELECT 
    season_id,
    AVG(points) as avg_points,
    AVG(fg_threes_attempted) as avg_three_attempts,
    AVG(fg_threes_percentage) as avg_three_pct
FROM Game
GROUP BY season_id
ORDER BY season_id;
```

**Visualization:** Line graph showing correlation between scoring trends and three-point attempts with trendlines

### 2. Historical Performance Tracking

**Query:** Analyze relationships between average points and shooting metrics since 1946-47 season

```sql
-- Correlation between points and shooting efficiency
SELECT 
    season_id,
    AVG(points) as avg_points,
    AVG(field_goal_percentage) as avg_fg_pct,
    AVG(fg_threes_percentage) as avg_three_pct,
    AVG(free_throw_percentage) as avg_ft_pct
FROM Game
GROUP BY season_id
ORDER BY season_id;
```

**Visualization:** Multiple line graphs with different y-axes to show correlations

### 3. Position-Based Rebounding Evolution

**Query:** Examine rebounding distribution across player positions over decades

```sql
-- Average rebounds by position over the years
SELECT 
    cpi.position,
    EXTRACT(YEAR FROM g.season_id) as year,
    AVG(pbs.rebounds) as avg_rebounds,
    AVG(pbs.offensive_rebounds) as avg_off_reb,
    AVG(pbs.defensive_rebounds) as avg_def_reb
FROM PlayerBoxScore pbs
JOIN CommonPlayerInfo cpi ON pbs.player_id = cpi.person_id
JOIN Game g ON pbs.game_id = g.game_id
GROUP BY cpi.position, EXTRACT(YEAR FROM g.season_id)
ORDER BY year, cpi.position;
```

**Visualization:** Bar charts comparing positions (Guard, Forward, Center) across time periods

### 4. Home Court Advantage Analysis

**Query:** Compare win rates for home vs. away games across seasons

```sql
-- Win rate comparison for home vs away games
SELECT 
    season_id,
    home_away,
    COUNT(CASE WHEN win_loss = 'W' THEN 1 END) * 100.0 / COUNT(*) as win_percentage
FROM Game
GROUP BY season_id, home_away
ORDER BY season_id;
```

**Visualization:** Bar chart or box-plot comparing distributions

### 5. Clutch Performance Metrics

**Query:** Analyze fourth-quarter performance in high-pressure playoff scenarios

```sql
-- Playoff performance analysis
SELECT 
    p.firstName,
    p.lastName,
    AVG(pbs.field_goal_percentage) as overall_fg_pct,
    AVG(CASE WHEN g.season_type = 'Playoffs' 
        THEN pbs.field_goal_percentage END) as playoff_fg_pct,
    AVG(pbs.points) as avg_points
FROM PlayerBoxScore pbs
JOIN Player p ON pbs.player_id = p.person_id
JOIN Game g ON pbs.game_id = g.game_id
GROUP BY p.firstName, p.lastName
HAVING AVG(CASE WHEN g.season_type = 'Playoffs' 
    THEN pbs.field_goal_percentage END) IS NOT NULL
ORDER BY playoff_fg_pct DESC;
```

**Visualization:** Histograms comparing distributions of shooting percentages

### 6. Era-Adjusted Player Evaluation

**Query:** Contextualize player performance within their era and team environment

```sql
-- Era-adjusted scoring analysis
SELECT 
    p.firstName,
    p.lastName,
    cpi.from_year,
    cpi.to_year,
    AVG(pbs.points) as avg_points,
    AVG(g.points) as team_avg_points,
    AVG(pbs.points) / NULLIF(AVG(g.points), 0) * 100 as scoring_share_pct
FROM PlayerBoxScore pbs
JOIN Player p ON pbs.player_id = p.person_id
JOIN CommonPlayerInfo cpi ON p.person_id = cpi.person_id
JOIN Game g ON pbs.game_id = g.game_id AND pbs.team_id = g.team_id
GROUP BY p.firstName, p.lastName, cpi.from_year, cpi.to_year
ORDER BY scoring_share_pct DESC;
```

**Visualization:** Parallel coordinate plots for multi-dimensional comparisons

---

## Installation & Setup

### Prerequisites

* Oracle SQL Developer (version 19c or higher recommended)
* Oracle Database (11g or higher)
* SQL*Plus or equivalent command-line tool
* Sufficient storage space (~5GB for complete dataset)

### Database Setup

1. **Clone the Repository**

```bash
git clone https://github.com/martinkent2003/NBATrends.git
cd NBATrends
```

2. **Create Database Tables**

Execute SQL scripts in the following order to maintain referential integrity:

```bash
# Connect to Oracle database
sqlplus username/password@database

# Create tables
@sql/create_tables.sql
```

**Table Creation Order:**
1. Team (no dependencies)
2. Player (no dependencies)
3. CommonPlayerInfo (depends on Player, Team)
4. DraftHistory (depends on Player, Team)
5. Game (depends on Team)
6. PlayerBoxScore (depends on Player, Game)

3. **Load Data**

```bash
# Load CSV data using SQL*Loader
sqlldr username/password@database control=sql/load_team.ctl
sqlldr username/password@database control=sql/load_player.ctl
sqlldr username/password@database control=sql/load_common_player_info.ctl
sqlldr username/password@database control=sql/load_draft_history.ctl
sqlldr username/password@database control=sql/load_game.ctl
sqlldr username/password@database control=sql/load_player_box_score.ctl
```

4. **Verify Data Integrity**

```sql
-- Check record counts for all tables
SELECT 'Player' as table_name, COUNT(*) as record_count FROM Player
UNION ALL
SELECT 'CommonPlayerInfo', COUNT(*) FROM CommonPlayerInfo
UNION ALL
SELECT 'Team', COUNT(*) FROM Team
UNION ALL
SELECT 'DraftHistory', COUNT(*) FROM DraftHistory
UNION ALL
SELECT 'Game', COUNT(*) FROM Game
UNION ALL
SELECT 'PlayerBoxScore', COUNT(*) FROM PlayerBoxScore;

-- Verify foreign key relationships
SELECT 
    constraint_name, 
    table_name, 
    constraint_type 
FROM user_constraints 
WHERE constraint_type = 'R';
```


## Usage

### Web Interface

1. Navigate to welcome page
2. Select query parameters or choose predefined graphs
3. View dynamic visualizations
4. Adjust parameters to refine analysis
5. Export results as needed

---

## Project Deliverables

* **Deliverable 1:** Project proposal and initial requirements
* **Deliverable 2:** ER diagram and conceptual database design
* **Deliverable 3:** SQL implementation and relational schema transformation

All deliverable documents are available in the `deliverables/` directory.

---

## Technologies Used

* **Database Management System:** Oracle SQL Developer
* **Query Language:** SQL (Oracle PL/SQL)
* **Data Source:** NBA Official Statistics API
* **Version Control:** Git & GitHub
* **Documentation:** Markdown, PDF
* **Frontend:** Angular 


---

## Database Statistics

| Table | Record Count | Description |
| ----- | ------------ | ----------- |
| Player | 4,815 | Active and historical NBA players |
| CommonPlayerInfo | 3,632 | Extended player biographical data |
| DraftHistory | 8,257 | Complete NBA draft records |
| Team | 30 | Current NBA teams |
| Game | 65,700+ | Historical game statistics |
| PlayerBoxScore | Extensive | Individual player game performances |

---

## Team Members

| Name | Role | Contributions |
| ---- | ---- | ------------- |
| **Martin Kent** | Database Design Lead | ER Diagram, Schema Design, Repository Management |
| **Alex Vargas** | Query Development | Complex Query Design, Optimization |
| **Joseph Cuenco** | Frontend Development | UI/UX Design, Visualization |
| **Ethan Alexander** | Data Analysis | Statistical Analysis, Query Testing |
| **Derek Meyer** | Documentation | Technical Writing, User Guides |

---

## Future Enhancements

* [ ] Real-time data integration with live NBA API feeds
* [ ] Machine learning models for player performance prediction
* [ ] Advanced analytics dashboards with interactive filtering
* [ ] Mobile application support (iOS/Android)
* [ ] User account management with saved queries and preferences
* [ ] Social features for sharing analyses and insights
* [ ] Export functionality for reports and visualizations
* [ ] Advanced statistical analysis (PER, Win Shares, VORP)

---

## Contributing

This project was developed as part of the **CIS4301 Database Management Systems** course. For questions or contributions, please contact team members through the university email system.

---

## License

This project is licensed for academic use only as part of the Spring 2024 CIS4301 course.

---

## Acknowledgments

* **NBA** for providing comprehensive statistical data
* **University of Florida** Database Management Systems program

---

## Contact

For questions, issues, or contributions, please contact:
* **Primary Contact:** Martin Kent (Repository Owner)
* **GitHub Issues:** [https://github.com/martinkent2003/NBATrends/issues](https://github.com/martinkent2003/NBATrends/issues)

---

**Last Updated:** Spring 2024  
**Version:** 1.0  
