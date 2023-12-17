fn main() {
    pub fn kids_with_candies(candies: Vec<i32>, extra_candies: i32) -> Vec<bool> {
        let max = candies.iter().max().unwrap();
        let mut final_candies: Vec<bool> = Vec::new();

        for candy in candies.iter() {
            let is_greater = candy + extra_candies >= *max;
            final_candies.push(is_greater);
        }

        return final_candies;
    }

    type TestCase = (Vec<i32>, i32, Vec<bool>);
    type TestCases = Vec<TestCase>;

    let test_cases: TestCases = vec![
        (vec![2, 3, 5, 1, 3], 3, vec![true, true, true, false, true]),
        (
            vec![4, 2, 1, 1, 2],
            1,
            vec![true, false, false, false, false],
        ),
        (vec![12, 1, 12], 10, vec![true, false, true]),
    ];

    pub fn test(test_cases: TestCases) {
        for (candies, extra_candies, expected) in test_cases.iter() {
            let result = kids_with_candies(candies.to_vec(), *extra_candies);

            println!("Passes: {}", result == *expected);
        }

        println!("Done!");
    }

    test(test_cases);
}
