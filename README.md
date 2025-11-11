Queries: 
Analyze how the three point shot has impacted scoring output in the NBA (general)
Query the average score of games in the NBA over time. Compare this to the query of the average amount of three points taken in a game. Queries can also be specified for specific teams. This can show how effective shooting three pointers over two pointers is.
	
Query the relationship between average points per game and other relevant data of this type on a yearly scale and oversee the development of the league as a whole since the inaugural 1946-47 NBA season. This ties in to the real world importance of our application because by analyzing the development of the league overtime it becomes possible to notice and predict certain trends that may occur in the future. 

Analyze how rebounding numbers for each position have changed over the years.
Query the average number of rebounds for each year. Filter this based on distinct player positions (point guard, center, etc.) An example of a conclusion based on the visualization: it may be the case that in the 1970’s, centers got all rebounds. However, in the past decade, perhaps point guards have been getting a larger percentage of rebounds.
The impact of Home vs Away has been a very prominent point of contention in the NBA. With our application a user will be able to query and compare several relevant stats when it comes to this topic such as the average win rate overall for away vs home, how it’s changed as the sport has evolved, how these stats vary from team to team and even player to player.
When it comes to player impact, a commonly discussed intangible is clutchness(the ability to perform under pressure to lead a team to success). This metric is often hard to analyze as statistics often lie, and although a player may have great shooting percentages he may not show up in late game scenarios or “big games” with higher stakes. To analyze this one could look up fourth quarter shot percentages in playoffs games 
Another common discussion topic is the skill level and greatness of players. Impact on a team sport is relative to the team the player is on and the era of basketball that the player is in. For example, in the 80’s teams averaged below 100 points per game and today teams are usually scoring in the 100’s, with rarely having games below 100. By that sense, since less points were the average before, scoring 25 points per game would be the 1980’s equivalent of scoring 30 points per game in today’s league. Therefore, some people argue that players nowadays are better than previous players; however, relative to what team they are on(based on what the team is averaging in terms of points and win percentage), and what era of basketball they play in, the greatness of a player can be interpreted based on averages of their teams and era. This will place data into perspective.




Tables:
Unique Key
Foreign Key
Player (4815)
person_id
first_name
last_name
is_active (ROSTERSTATUS)// maybe calculate from to_year as a derived attribute

Common Player Info (3632)
person_id
player_slug
birthdate
school
country
height
weight
seasons_exp
jersey(#)
position
team_id
from_year
to_year
dleague_flag
greatest_75_flag

Draft History (8257)
person_id
season
round_number
round_pick
overall_pick
team_id
organization
organization_type
player_profile_flag

Team (30)
team_id
full_name
abbreviation
nickname
year_founded
Facebook, 
Instagram
Twitter

Game (65.7k)
season_id 
team_id_home
team_id_away
game_id
Wl_home
field_goals_made_home
field_goals_attempted_home
field_goal_percentage_home
fg_threes_made_home
fg_threes_attempted_home
fg_threes_percentage_home
free_throws_made_home
free_throws_attempted_home
free_throw_percentage_home
offensive_rebounds_home
defensive_rebounds_home
assists_home
steals_home
blocks_home
turnovers_home
personal_fouls_home
points_home
plus_minus_home
season_type

Box Score (many)
season_id
player_id
team_id
game_id
win_loss
minutes
field_goals_made
field_goals_attempted
field_goal_percentage
fg_threes_made
fg_threes_attempted
fg_threes_percentage
free_throws_made
free_throws_attempted
free_throw_percentage
offensive_rebounds
defensive_rebounds
rebounds
assists
steals
blocks
turnovers
personal_fouls
points
Plus_minus




NBA Data Trend Analysis 
Spring 2024
Group 13: Martin Kent, Alex Vargas, Joseph Cuenco, Ethan Alexander, Derek Meyer
Project Deliverable 2

Overview and Description of the Application
The database design focuses on providing NBA fans, coaches, and league executives with a comprehensive platform for exploring and analyzing various basketball-related statistics. In the world of the NBA, fans often debate key topics such as offensive performance trends and player impacts on team success. This database provides fans with access to a wealth of statistical data, enabling them to support their arguments with concrete evidence and gain deeper insights into the intricacies of the game. Additionally, this database serves as a valuable tool for coaches, providing them with access to comprehensive statistical data that can aid in performance evaluation, opponent scouting, and game planning. For instance, understanding the correlation between a team's three-point shooting volume and its win percentage over time can help coaches optimize their team's offensive strategies and player rotations. 
In terms of functionality, users will interact with the database through a form on the website where they input desired data. Form data includes parameters such as time range, team selection, specific statistics for analysis, and player identification. Based on the form, the system constructs and executes the desired query and retrieves relevant data from the database. The data is presented in graphs to allow users to easily interpret and visualize statistical trends and patterns. Users have the flexibility to adjust query parameters dynamically, allowing them to explore different datasets and scenarios. For example, users have the option to request data for an additional team beyond those already selected, or they can alter the time period to refine their analysis. In addition to personalized graphs, the interface offers predefined graphs that display significant statistics and complex trends. The parameters of predefined graphs can also be adjusted according to user preferences.
	Example Queries:
Analyze how the three point shot has impacted scoring output in the NBA overall. 

This involves querying the average score of NBA games across different time periods and comparing it with the average number of three-point shots attempted per game. Additionally, specific team queries can be conducted to assess the effectiveness of three-point shooting relative to two-pointers. Analyzing the average game scores across various time frames alongside the average number of three-point attempts per game, we can gain insights useful for improving scoring efficiency. Through specific team queries, we can evaluate how teams' preferences for three-point shooting versus traditional two-pointers correlate with their overall performance.

Query the relationship between average points scored and metrics such as field goal percentage, three-point shooting accuracy, free throw efficiency on an annual basis.

This involves calculating and visualizing the correlation between such metrics to describe what factors contribute to successful game performances. Understanding how these trends have changed over time since the inaugural 1946-47 season is crucial for predicting future developments in the league and gaining insights into strategic shifts and player performance dynamics.

Examine the historical evolution of rebounding statistics across different player positions in the NBA. 

This involves calculating the average number of rebounds per year, segmented by distinct player positions such as point guard and center. From these metrics, we would create visualizations to discern patterns and shifts in rebound distribution over time. For instance, while centers traditionally dominated rebounding in the 1970s, recent trends might suggest a redistribution of rebounding responsibilities, with point guards gaining an increasingly larger share in the past decade. This analysis offers valuable insights into strategic changes, player roles, and evolving game dynamics, aiding coaches, analysts, and teams in optimizing player utilization and team performance strategies.

Examine the overall average win rate for away versus home games, tracking how this trend has evolved over time as the sport has progressed and assessing the variability of these statistics across different teams and individual players. 

Through such analysis, users can gain statistical insights into a prominent point of contention: the significance of home-court advantage and its impact on team performance in the NBA. 

Analyze fourth-quarter shot percentages in comparison to overall shot percentages to provide a nuanced perspective on a player’s ability to deliver when under the most pressure. Additionally, these statistics can be limited to playoff games to further increase stakes.

When evaluating player impact, a frequently debated intangible is "clutchness," defined as the ability to perform under pressure and lead a team to success in critical moments. This query allows teams and fans to evaluate players' abilities to deliver in clutch situations, ultimately influencing strategic decisions and player assessments.

Evaluate the skill level of NBA athletes in relation to factors such as the team they play for and the era of basketball they compete in.

The perceived greatness and skill of a player is inherently related to such factors. For instance, during the 1980s, teams typically scored below 100 points per game, whereas in the contemporary NBA, teams often score in the 100s, with scores below 100 points being rare. Consequently, scoring 25 points per game in the 1980s would be equivalent to scoring 30 points per game in today's league in terms of perceived impact. This comparison leads to arguments suggesting that modern players surpass their predecessors in skill level. However, the assessment of a player's greatness should consider how they succeeded in relation to their environment. By contextualizing player statistics within the averages of their teams and basketball eras, a more accurate assessment of their performance and impact can be achieved.


User Interface Design Including the Application-specific Network or Graph of Web Pages and the Integration of the Complex Trend Queries

Web Page Purpose, Functionality, and Control Flow
The application will contain three web pages for the user to access. The first will be a welcome page that introduces the application, describes how the application is helpful, and gives viewers an idea of how to navigate the application. The only interactive feature of this introductory page will be a button that the user can click to bring them to the second page, where the user will be asked to fill out a form about what data they would like to view. The form will be formatted as multiple choice questions of options for categories such as time period, team selection, player identification, and game statistics. Where applicable, users will be able to select multiple options to, for example, select multiple teams to compare or view several game-related statistics. There will also be the option for users to bypass the form and choose from a set of predefined graphs that show relevant and significant trends that would commonly be requested. Either selecting one of the graphs or submitting the form will transfer the user to the third page, which displays the requested data as graphs. On this page, users will be able to dynamically customize certain parameters in order to, for example, alter the visible time period or select another team to analyze. This will be possible through a set of drag-down text boxes that will be visible alongside the graphs. On this third page, users will be able to return to the second page and create a new query. 
Transformation of User Input into Queries and Visualizations
All of the parameters that the user can choose correspond to the data in the database and depending on what the user requests, the application retrieves the relevant information, and displays it graphically. For example, if a user requests to look only data involving the Miami Heat, the query algorithms will limit the data processed and visualized to only data involving the Miami Heat.
Output Format
The graphs will show requested statistics vs time. Multiple data representations like line graphs and histograms will be used to represent the data, depending on what statistics the user would like to view. For example, for the analysis of three-point shooting trends over time, statistics such as the average number of three-point attempts per game and the three-point shooting percentage for each season can be depicted using line graphs and the distribution of three-point attempts per game across different seasons can be visualized via a histogram.
Visualization for Complex Queries
Analyze how the three point shot has impacted scoring output in the NBA overall. 
Trends can be represented by a line graph showing trends in average game scores over time with a second line representing the average number of three-point attempts per game and by scatter plots comparing average score and average-three point attempts, with a trendline displaying correlation between the two.
Query the relationship between average points scored and metrics such as field goal percentage, three-point shooting accuracy, free throw efficiency on an annual basis.

These trends can be displayed through line graphs showing the relationship between average scores and the desired metrics, such as three-point percentage, rebounding numbers, etc. There would be multiple line graphs with different y-axes next to each other, so correlations can be seen.

Examine the historical evolution of rebounding statistics across different player positions in the NBA. 

Trends can be visualized through multiple bar charts comparing average rebounds per game for different player positions across different time frames. Positions include guard, forward, and center.

Examine the overall average win rate for away versus home games, tracking how this trend has evolved over time as the sport has progressed and assessing the variability of these statistics across different teams and individual players. 

Trends can be visualized through a bar chart with distinct bars for home and away games showing average win rates for the two. Similarly, this could be represented through a box-plot to compare the two distributions.

Analyze fourth-quarter shot percentages in comparison to overall shot percentages to provide a nuanced perspective on a player’s ability to deliver when under the most pressure. Additionally, these statistics can be limited to playoff games to further increase stakes.

Trends can be visualized through histograms comparing the distributions of fourth-quarter shot percentages and overall shot percentages for all players.

Evaluate the skill level of NBA athletes in relation to factors such as the team they play for and the era of basketball they compete in.
These comparisons can be visualized through parallel coordinate plots, allowing users to visualize scale and distribution differences across different eras.

Conceptual Database Design Based on the Entity-Relationship Model and a Careful Analysis of the Deployed Data Sources






Entities and Attributes (Entity [Attribute1, … , Attribute n])
Player [person_id, first_name, last_name, is_active]

Common Player Info [person_id, player_slug, birthdate, school, country, height, weight, seasons_exp, jersey(#), position, team_id, from_year, to_year, dleague_flag, greatest_75_flag]

Draft History [person_id, season, round_number, round_pick, overall_pick, team_id, organization, organization_type, player_profile_flag]

Team [team_id, full_name, abbreviation, nickname, year_founded, Facebook, , Instagram, Twitter]

Game [game_id, season_id, team_id_home, team_id_away, Wl_home, field_goals_made_home, field_goals_attempted_home, field_goal_percentage_home, fg_threes_made_home, fg_threes_attempted_home, fg_threes_percentage_home, free_throws_made_home, free_throws_attempted_home, free_throw_percentage_home, offensive_rebounds_home, defensive_rebounds_home, assists_home, steals_home, blocks_home, turnovers_home, personal_fouls_home, points_home, plus_minus_home, season_type]

Box Score [season_id, player_id, team_id, game_id, win_loss, minutes, field_goals_made, field_goals_attempted, field_goal_percentage, fg_threes_made, fg_threes_attempted, fg_threes_percentage, free_throws_made, free_throws_attempted, free_throw_percentage, offensive_rebounds, defensive_rebounds, rebounds, assists, steals, blocks, turnovers, personal_fouls, points, Plus_minus]

Relationships
Player-Has-DraftHistory
An Identifying relationship. DraftHistory is identified by the PlayerID of the player who was drafted along with TeamID of the drafting team.
Cardinalities
Player (1) : Each player was drafted once.
DraftHistory (1) : Each DraftHistory entry corresponds to one player
Participation
Player (Partial) : Some players went undrafted. This means they were not selected by a team in a draft, but were signed by a team later.
DraftHistory (Total) : Each entry of a draft pick has to relate to a player.

DraftHistory-DraftedBy-Team
Cardinalities
DraftHistory (N) : A team has many draft picks
Team (1) : Each draft pick is made by only one team
Participation
DraftHistory (Total) : A draft pick must correspond to a team
Team (Total) : Every team has made at least one draft pick
Player-Has-CommonPlayerInfo
An Identifying relationship. CommonPlayerInfo provides a lot of additional information about a player that is useful for filtering. However, a lot of players from decades ago are missing this information. To avoid a lot of NULL entries, these attributes were moved to another table and identified to be a weak entity.
Cardinalities
Player (1) : Player has at most one common player info
CommonPlayerInfo (1) : Info corresponds to only one player
Participation
Player (Partial) : Some players do not have additional information
CommonPlayerInfo (Total) : Additional information must be related to a player
CommonPlayerInfo-PlaysFor-Team
Cardinalities
CommonPlayerInfo (N) : Team has many players
Team (1) : Player plays for only one team
Participation
CommonPlayerInfo (Partial) : A player may no longer be on a team
Team (Total) : Every team has players on their roster
Team-Plays-Game
Cardinalities
Team (2) : 2 teams participate in each game
Game (N) : A team plays many games
Participation
Team (Total) : Every team has played games
Game (Total) : Every game involved exactly 2 teams
Player-Has-PlayerBoxScore
PlayerBoxScore stores all players’ stats for each individual game
Cardinalities
Player (1) : A box score record is for only one player
PlayerBoxScore (N) : Player has a box score for each game they play
Participation
Player (Partial) : Unfortunately some players never played in a game
PlayerBoxScore (Total) : Box score must correspond to a player
PlayerBoxScore-PlayedFor-Team
Matches a player’s box score to the team they were playing for
Cardinalities
PlayerBoxScore (N) : Each team has multiple PlayerBoxScore entries. One for each player for each game
Team (1) : Player’s box score data is for one team
Participation
PlayerBoxScore (Total) : Box score record must be for a team
Team (Total) : Every team has box score data
PlayerBoxScore-PlayedIn-Game
Matches a player’s box score to the game in which it was for
Cardinalities
PlayerBoxScore (N) : Each game has multiple players participating, therefore multiple box score records
Game (1) : Each box score data record corresponds to one game
Participation
PlayerBoxScore (Total) : Every box score record must relate to a game
Game (Total) : Every game has box score data

Relation to Database and Other Significant Details
Because our project will mainly focus on the presentation of player and game stats over time we wanted our diagram to accurately represent and provide connections between these attributes. We looked over our database and determined all relevant information and statistics that our queries would be relying on, these are the attributes of our ERD shown above. The criteria for an attribute to be considered significant to us was twofold, we included anything that we believed our stated 6 complex queries would rely on, for instance one of our queries involves analyzing 4th quarter shot percentages in an attempt to derive a players “clutchness”, therefore attributes like field goal percentages, field goal threes percentages, and free throw percentages specifically from a player would be very important. Therefore we knew an entity like player box score which would include all player specific stats would be necessary, the entities draft history and game/teamstats were included using similar logic. Secondly we chose to include all attributes under the entities we knew we would be including we believed would make for a better user experience on our site such as team’s social media pages so that we could display those for users to check out. After determining which attributes we needed it was a matter of figuring out what entities we wanted to include to encompass these, and which entities would be necessary in order to form connections and provide a proper picture of the data we wanted to represent. From our attributes we knew we would need entities like PlayerBoxScore, GameStats/TeamStats, and DraftHistory, and from these entities we knew we would need entities like Player, Team, and player info. From there we included our previously discussed necessary attributes, our entities primary id’s, and attributes for Player, CommonPlayerInfo, and Team that we knew we wanted to include to act as a supporting extension to our main entities like player and team stats that belonged to these entities in our database such as things like team name, and player name. After determining all the entities and attributes we would be using we made our relationships with the intent of connecting all entities that directly shared Primary/Foreign keys with each other in order to make our diagram cohesive. We also connected the entities with supporting attributes to the entities with our main query attributes, for instance we determined a relationship exists between player and PlayerBoxScore. In naming our entities/attributes we pulled directly from our selected database, we also made a point not to take too many liberties in the structure of the attribute-entity relationship our database already had detailed for us. For instance teamstats could very well have been a separate entity in a relationship with game, for both away and home, but because that was not how our database presented the information we didn't want our diagram to present the information in that manner either.

