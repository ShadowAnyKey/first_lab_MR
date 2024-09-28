class GameEngine:
    def __init__(self, name):
        self.name = name
        self.user_name = ''

    def greet_user(self):
        print(self.name)
        print("Welcome to the Brain Games!")
        self.user_name = input("May I have your name? ")
        print(f"Hello, {self.user_name}!")

    def play(self, game_description, generate_question_and_answer, rounds=3, endless=False):
        self.greet_user()
        print(game_description)
        rounds_played = 0

        while endless or rounds_played < rounds:
            question, correct_answer = generate_question_and_answer()
            print(f"Question: {question}")
            user_answer = input("Your answer: ")

            if user_answer == str(correct_answer):
                print("Correct!")
                rounds_played += 1
            else:
                print(f"'{user_answer}' is wrong answer ;(. Correct answer was '{correct_answer}'.")
                print(f"Let's try again, {self.user_name}!")
                return

        print(f"Congratulations, {self.user_name}!")